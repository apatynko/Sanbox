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
    class Chapter12
    {
        Vector3 Color(Ray r, HitableList world, int depth)
        {
            HitRecord rec = new HitRecord();
            if (world.hit(r, 0.001f, float.MaxValue, ref rec))
            {
                Ray scattered = null;
                Vector3 attenuation = new Vector3(0, 0, 0);
                if (depth < 50 && rec.mat.scatter(r, rec, ref attenuation, ref scattered))
                {
                    return attenuation * Color(scattered, world, depth + 1);
                }
                else
                {
                    return new Vector3(0, 0, 0);
                }
            }
            else
            {
                Vector3 unitDirection = Vector3.Normalize(r.Direction());
                float t = 0.5f * (unitDirection.Y + 1.0f);
                return (1.0f - t) * new Vector3(1.0f, 1.0f, 1.0f) + t * new Vector3(0.5f, 0.7f, 1.0f);
            }
        }

        static public HitableList random_scene()
        {
            Random rdm = new Random(Guid.NewGuid().GetHashCode());
            Hitable[] objList = new Hitable[501];
            int i = 0;
            objList[i] = new Sphere(new Vector3(0f, -1000f, 0f), 1000f, new Lambertian(new Vector3(.5f, .5f, .5f)));
            for (int a = -11; a < 11; ++a)
                for (int b = -11; b < 11; ++b)
                {
                    double choose_mat = rdm.NextDouble();
                    Vector3 center = new Vector3((float)(a + 0.9 * rdm.NextDouble()), 0.2f, (float)(b + 0.9 * rdm.NextDouble()));
                    if ((center - new Vector3(4f, .2f, 0f)).LengthSquared() > 0.81f)
                    {
                        if (choose_mat < 0.8)   // diffuse
                        {
                            ++i;
                            objList[i] = new Sphere(center, 0.2f, new Lambertian(new Vector3((float)rdm.NextDouble(), (float)rdm.NextDouble(), (float)rdm.NextDouble())));
                        }
                        else if (choose_mat < 0.95)
                        {
                            ++i;
                            objList[i] = new Sphere(center, 0.2f, new Metal(new Vector3((float)(0.5f * (1 + rdm.NextDouble())), (float)(0.5f * (1 + rdm.NextDouble())), (float)(0.5f * (1 + rdm.NextDouble())))));
                        }
                        else
                        {
                            ++i;
                            objList[i] = new Sphere(center, 0.2f, new Dielectric(1.5f));
                        }
                    }
                }
            objList[++i] = new Sphere(new Vector3(0, 1, 0), 1.0f, new Dielectric(1.5f));
            objList[++i] = new Sphere(new Vector3(-4, 1, 0), 1.0f, new Lambertian(new Vector3(0.4f, 0.2f, 0.1f)));
            objList[++i] = new Sphere(new Vector3(4, 1, 0), 1.0f, new Metal(new Vector3(0.7f, 0.6f, 0.5f), 0.0f));
            return new HitableList(objList);
        }


        public void Run()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int nx = 1280;
            int ny = 760;


            // link to ppm viewer
            // http://www.cs.rhodes.edu/welshc/COMP141_F16/ppmReader.html

            HitableList world = random_scene();

            Vector3 lookfrom = new Vector3(13f, 2f, 3f);
            Vector3 lookat = new Vector3(0f, 0f, 0f);
            float dist_to_focus = (lookfrom - lookat).Length();
            float aperture = 0f;
            Camera cam = new Camera(lookfrom, lookat, new Vector3(0f, 1f, 0f), 30f, (float)nx / (float)ny, aperture, 0.7f * dist_to_focus);
            
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
                            Ray r = cam.getRayDOF(u, v);
                            Vector3 p = r.PointAtParameter(2);
                            col += Color(r, world, 10);
                        }


                        col /= (float)sampleCount;
                        col = new Vector3((float)(Math.Sqrt(col.X)), (float)Math.Sqrt(col.Y),
                            (float)Math.Sqrt(col.Z));
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
