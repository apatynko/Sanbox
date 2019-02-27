using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapters
{
    public class HitableList
    {
        Hitable[] hitableList = new Hitable[0];

        public HitableList(Hitable[] _hitableList) { this.hitableList = _hitableList; }

        public bool hit(Ray r, float t_min, float t_max, ref HitRecord rec)
        {
            HitRecord temp_rec = new HitRecord();
            bool hit_something = false;
            float closest_so_far = t_max;
            foreach (Hitable h in this.hitableList)
            {
                if (h == null)
                    continue;
                if (h.hit(r, t_min, closest_so_far, ref temp_rec))
                {
                    hit_something = true;
                    closest_so_far = temp_rec.t;
                    rec = temp_rec;
                }
            }
            return hit_something;
        }
    }
}
