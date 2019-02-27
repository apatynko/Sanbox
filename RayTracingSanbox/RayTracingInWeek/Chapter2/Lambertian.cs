using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Chapters
{
    public class Lambertian : Material
    {
        Vector3 albedo; 
        public Lambertian(Vector3 _albedo) { this.albedo = _albedo; }
        public bool scatter(Ray r, HitRecord rec, ref Vector3 attattenuation, ref Ray scattered)
        {
            Vector3 target = rec.p + rec.normal + Sphere.random_in_unit_sphere();
            scattered = new Ray(rec.p, target - rec.p);
            attattenuation = albedo;
            return true;
        }
    }
}
