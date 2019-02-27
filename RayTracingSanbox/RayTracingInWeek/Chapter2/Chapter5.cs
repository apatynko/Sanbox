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
    class Chapter5
    {
        float HitSphere(Vector3 center, float radius, Ray r)
        {
            Vector3 oc = r.Origin() - center;
            float a = Vector3.Dot(r.Direction(), r.Direction());
            float b = 2.0f * Vector3.Dot(oc, r.Direction());
            float c = Vector3.Dot(oc, oc) - radius * radius;
            float discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
            {
                return -1.0f;
            }
            else
            {
                return (-b - (float)Math.Sqrt((double)discriminant)) / (2.0f * a);
            }
        }

        Vector3 Color(Ray r)
        {
            float t = HitSphere(new Vector3(0.0f, 0.0f, -1.0f), 0.5f, r);
            if (t > 0.0f)
            {
                Vector3 N = Vector3.Normalize(r.PointAtParameter(t) - new Vector3(0.0f, 0.0f, -1.0f));
                return 0.5f * new Vector3(N.X + 1.0f, N.Y + 1.0f, N.Z + 1.0f);
            }

            Vector3 unitDirection = Vector3.Normalize(r.Direction());
            t = 0.5f * (unitDirection.Y + 1.0f);
            return (1.0f - t) * new Vector3(1.0f, 1.0f, 1.0f) + t * new Vector3(0.5f, 0.7f, 1.0f);
        }


        public void Run()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int nx = 200;
            int ny = 100;
            // link to ppm viewer
            // http://www.cs.rhodes.edu/welshc/COMP141_F16/ppmReader.html

            Vector3 lowerLeftCorner = new Vector3(-2.0f, -1.0f, -1.0f);
            Vector3 horizontal = new Vector3(4.0f, 0.0f, 0.0f);
            Vector3 vertical = new Vector3(0.0f, 2.0f, 0.0f);
            Vector3 origin = new Vector3(0.0f, 0.0f, 0.0f);

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
                        float u = (float)i / (float)nx;
                        float v = (float)j / (float)ny;
                        Ray r = new Ray(origin, lowerLeftCorner + u * horizontal + v * vertical);

                        Vector3 col = Color(r);

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

    class Chapter5_2
    {
        //float HitSphere(Vector3 center, float radius, Ray r)
        //{
        //    Vector3 oc = r.Origin() - center;
        //    float a = Vector3.Dot(r.Direction(), r.Direction());
        //    float b = 2.0f * Vector3.Dot(oc, r.Direction());
        //    float c = Vector3.Dot(oc, oc) - radius * radius;
        //    float discriminant = b * b - 4 * a * c;
        //    if (discriminant < 0)
        //    {
        //        return -1.0f;
        //    }
        //    else
        //    {
        //        return (-b - (float)Math.Sqrt((double)discriminant)) / (2.0f * a);
        //    }
        //}

        Vector3 Color(Ray r, HitableList world)
        {
            HitRecord rec = new HitRecord();
            if (world.hit(r, 0.0f, float.MaxValue, ref rec))
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

            Vector3 lowerLeftCorner = new Vector3(-2.0f, -1.0f, -1.0f);
            Vector3 horizontal = new Vector3(4.0f, 0.0f, 0.0f);
            Vector3 vertical = new Vector3(0.0f, 2.0f, 0.0f);
            Vector3 origin = new Vector3(0.0f, 0.0f, 0.0f);

            Hitable[] objList = new Hitable[2];
            objList[0] = new Sphere(new Vector3(0, 0, -1), 0.5f);
            objList[1] = new Sphere(new Vector3(0, -100.5f, -1), 100);

            HitableList world = new HitableList(objList);

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
                        float u = (float)i / (float)nx;
                        float v = (float)j / (float)ny;
                        Ray r = new Ray(origin, lowerLeftCorner + u * horizontal + v * vertical);
                        Vector3 p = r.PointAtParameter(2);
                        Vector3 col = Color(r, world);

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
