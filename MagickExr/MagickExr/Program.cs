using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ImageMagick;

namespace MagickExr
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MagickImage hdrImage =
                new MagickImage(
                    @"d:\DEV_stuff\DEV\sharpexr\EXRViewer\bin\Debug\AmericanKitchen_OI2_2.VRayDiffuseFilterPS.exr ", new PixelReadSettings()))
            {
                Console.WriteLine("Reading image");
                IPixelCollection pixels = hdrImage.GetPixels();
                for (int y = 0; y < hdrImage.Height; y++)
                {
                    for (int x = 0; x < hdrImage.Width; x++)
                    {
                        MagickColor p = pixels.GetPixel(x, y).ToColor();
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
