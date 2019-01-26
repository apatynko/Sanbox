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
    public class Chapter2
    {
        public void Run()
        {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        int nx = 200;

        int ny = 100;
        // link to ppm viewer
        // http://www.cs.rhodes.edu/welshc/COMP141_F16/ppmReader.html

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
                    Vector3 col = new Vector3(
                        (float) i / (float) nx,
                        (float) j / (float) ny,
                        0.2f);

                    int ir = (int) (255.99 * col.X);
                    int ig = (int) (255.99 * col.Y);
                    int ib = (int) (255.99 * col.Z);
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
