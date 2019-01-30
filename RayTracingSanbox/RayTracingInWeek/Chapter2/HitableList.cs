using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapters
{
    public class HitableList: Hitable
    {
        public HitableList() { }

        public HitableList(List<Hitable> l)
        {
            this.list = l;
        }

        public int listSize;
        public List<Hitable> list;

        public override bool Hit(Ray r, float t_min, float t_max, HitRecord rec)
        {
            HitRecord tempRec = new HitRecord();
            bool hitAnything = false;
            float closestSoFar = t_max;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Hit(r, t_min, closestSoFar, tempRec))
                {
                    hitAnything = true;
                    closestSoFar = tempRec.t;
                    rec = tempRec;
                }
            }

            return hitAnything;
        }
    }
}
