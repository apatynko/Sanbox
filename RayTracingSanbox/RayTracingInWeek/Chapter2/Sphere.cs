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

        public override bool Hit(Ray r, float t_min, float t_max, ref HitRecord rec)
        {
            Vector3 oc = r.Origin() - center;
            float a = Vector3.Dot(r.Direction(), r.Direction());
            float b = 2.0f * Vector3.Dot(oc, r.Direction());
            float c = Vector3.Dot(oc, oc) - radius * radius;
            float discriminant = b * b - 4 * a * c;
            if (discriminant > 0)
            {
                float temp = (float) ((-b - Math.Sqrt(discriminant)) / 2 * a);
                if (temp <= t_max && temp >= t_min)
                {
                    rec.t = temp;
                    rec.p = r.PointAtParameter(rec.t);
                    rec.normal = (rec.p - center) / radius;
                    return true;
                }
                temp = (float)((-b + Math.Sqrt(discriminant)) / 2 * a);
                if (temp <= t_max && temp >= t_min)
                {
                    rec.t = temp;
                    rec.p = r.PointAtParameter(rec.t);
                    rec.normal = (rec.p - center) / radius;
                    return true;
                }
            }

            return false;
        }


        public static Vector3 random_in_unit_sphere()
        {
            // should NOT use new Random(), if it run fast enough then all rdm use the same seed
            Random rdm = new Random(Guid.NewGuid().GetHashCode());
            Vector3 p;
            do
            {
                p = 2 * new Vector3(
                        (float)rdm.NextDouble(),
                        (float)rdm.NextDouble(),
                        (float)rdm.NextDouble()) - new Vector3(1, 1, 1);
            } while (p.LengthSquared() >= 1.0);
            return p;
        }


        // these method cause StackOverflowException
        // should be used like Random rdm = new Random(Guid.NewGuid().GetHashCode()); 
        // instead of Random rdm = new Random();
        public static Vector3 random_in_unit_sphere_book()
        {
            Random rdm = new Random();
            Vector3 p;
            do
            {
                p = 2 * new Vector3(
                        (float)rdm.NextDouble(),
                        (float)rdm.NextDouble(),
                        (float)rdm.NextDouble()) - new Vector3(1, 1, 1);
            } while (p.LengthSquared() >= 1.0);
            return p;
        }

        private Vector3 center;
        private float radius;
    }
}
