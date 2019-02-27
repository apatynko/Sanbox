using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Chapters
{


    class Chapter7
    {
        

        Vector3 Color(Ray r, HitableList world)
        {
            HitRecord rec = new HitRecord();
            if (world.hit(r, 0.001f, float.MaxValue, ref rec))
            {
                Vector3 target = rec.p + rec.normal + Sphere.random_in_unit_sphere();
                return 0.5f * Color(new Ray(rec.p, target - rec.p), world);
            }
            else
            {
                Vector3 unitDirection = Vector3.Normalize(r.Direction());
                float t = 0.5f * (unitDirection.Y + 1.0f);
                return (1.0f - t) * new Vector3(1.0f, 1.0f, 1.0f) + t * new Vector3(0.5f, 0.7f, 1.0f);
            }
        }


        public void Run()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int nx = 200;
            int ny = 100;


            // link to ppm viewer
            // http://www.cs.rhodes.edu/welshc/COMP141_F16/ppmReader.html

            Hitable[] objList = new Hitable[2];
            objList[0] = new Sphere(new Vector3(0, 0, -1), 0.5f);
            objList[1] = new Sphere(new Vector3(0, -100.5f, -1), 100);

            HitableList world = new HitableList(objList);

            Camera cam = new Camera();
            int sampleCount = 100;
            Random rdm = new Random();

            string filePath = @"d:\DEV_stuff\DEV\Sanbox\RayTracingSanbox\RayTracingInWeek\Output";

            if (File.Exists(Path.Combine(filePath, "texture.ppm")))
            {
                File.Delete(Path.Combine(filePath, "texture.ppm"));
                Console.WriteLine("Deleted file: " + Path.Combine(filePath, "texture.ppm"));
            }

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(filePath, "texture.ppm"), true))
            {
                outputFile.Write("P3\n" + nx + " " + ny + "\n255\n");
                //Console.Write("P3\n" + nx + " " + ny + "\n255\n");
                for (int j = ny - 1; j >= 0; j--)
                {
                    for (int i = 0; i < nx; i++)
                    {
                        Vector3 col = new Vector3(0, 0, 0);
                        for (int c = 0; c < sampleCount; c++)
                        {
                            float u = ((float)i + (float)rdm.NextDouble()) / (float)nx;
                            float v = ((float)j + (float)rdm.NextDouble()) / (float)ny;
                            Ray r = cam.get_ray(u, v);
                            Vector3 p = r.PointAtParameter(2);
                            col += Color(r, world);
                        }


                        col /= (float)sampleCount;
                        col = new Vector3((float)(Math.Sqrt(col.X)), (float)Math.Sqrt(col.Y), (float)Math.Sqrt(col.Z));
                        int ir = (int)(255.99 * col.X);
                        int ig = (int)(255.99 * col.Y);
                        int ib = (int)(255.99 * col.Z);
                        outputFile.Write(ir + " " + ig + " " + ib + "\n");
                        //Console.Write(ir + " " + ig + " " + ib + "\n");
                    }
                }
            }

            sw.Stop();

            Console.WriteLine("Time to output image with StreamWriter : " + sw.ElapsedMilliseconds.ToString() + " ms");
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
    }
}
