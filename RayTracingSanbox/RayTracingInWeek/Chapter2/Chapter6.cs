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
    

    class Chapter6
    {

        Vector3 Color(Ray r, Hitable world)
        {
            HitRecord rec = new HitRecord();
            if (world.Hit(r, 0.0f, float.MaxValue, ref rec))
            {
                return 0.5f * new Vector3(rec.normal.X + 1.0f, rec.normal.Y + 1.0f, rec.normal.Z + 1.0f);
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

            List<Hitable> list = new List<Hitable>();
            list.Add(new Sphere(new Vector3(0.0f, 0.0f, -1.0f), 0.5f));
            list.Add(new Sphere(new Vector3(0.0f, -100.5f, -1.0f), 100.0f));

            Hitable world = new HitableList(list);

            Camera cam  = new Camera();
            int sampleCount = 10;
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
