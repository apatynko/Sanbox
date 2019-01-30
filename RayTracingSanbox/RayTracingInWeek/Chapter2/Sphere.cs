using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Chapters
{
    class Sphere: Hitable
    {
        public Sphere()
        {
            
        }

        public Sphere(Vector3 cet, float r)
        {
            center = cet;
            radius = r;
        }

        public override bool Hit(Ray r, float t_min, float t_max, HitRecord rec)
        {
            Vector3 oc = r.Origin() - center;
            float a = Vector3.Dot(r.Direction(), r.Direction());
            float b = 2.0f * Vector3.Dot(oc, r.Direction());
            float c = Vector3.Dot(oc, oc) - radius * radius;
            float discriminant = b * b - 4 * a * c;
            if (discriminant > 0)
            {
                float temp = (float) ((-b - Math.Sqrt(b * b - a * c)) / 2 * a);
                if (temp < t_max && temp > t_min)
                {
                    rec.t = temp;
                    rec.p = r.PointAtParameter(rec.t);
                    rec.normal = (rec.p - center) / radius;
                    return true;
                }
                temp = (float)((-b + Math.Sqrt(b * b - a * c)) / 2 * a);
                if (temp < t_max && temp > t_min)
                {
                    rec.t = temp;
                    rec.p = r.PointAtParameter(rec.t);
                    rec.normal = (rec.p - center) / radius;
                    return true;
                }
            }

            return false;
        }

        private Vector3 center;
        private float radius;
    }
}
