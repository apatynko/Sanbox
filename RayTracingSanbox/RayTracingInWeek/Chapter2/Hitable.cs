using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapters
{
    public abstract class Hitable
    {
        public virtual bool Hit(Ray r, float t_min, float t_max, HitRecord rec)
        {
            return false;
        }
    }
}
