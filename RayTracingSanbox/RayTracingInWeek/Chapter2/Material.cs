using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;


namespace Chapters
{
    public interface Material
    {
        bool scatter(Ray r, HitRecord rec, ref Vector3 attenuation, ref Ray scattered);
    }
}
