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
    class Chapter4
    {
        bool HitSphere(Vector3 center, float radius, Ray r)
        {
            Vector3 oc = r.Origin() - center;
            float a = Vector3.Dot(r.Direction(), r.Direction());
            float b = 2.0f * Vector3.Dot(oc, r.Direction());
            float c = Vector3.Dot(oc, oc) - radius * radius;
            float discriminant = b * b - 4 * a * c;
            return (discriminant > 0);
        }

        Vector3 Color(Ray r)
        {
            if (HitSphere(new Vector3(0.0f, 0.0f, -1.0f), 0.5f, r))
                return new Vector3(1.0f, 0.0f, 0.0f);

            Vector3 unitDirection = Vector3.Normalize(r.Direction());
            float t = 0.5f * (unitDirection.Y + 1.0f);
            return (1.0f - t) * new Vector3(1.0f, 1.0f, .0f) + t * new Vector3(0.5f, 0.7f, 1.0f);
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
}
