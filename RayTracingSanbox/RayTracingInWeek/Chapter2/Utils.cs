using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Chapters
{
    public static class Utils
    {
        public static bool refract(Vector3 view, Vector3 normal, float nview_over_nt, ref Vector3 refracted)
        {
            Vector3 uv = Vector3.Normalize(view);
            float dt = Vector3.Dot(uv, normal);
            float discriminant = 1.0f - nview_over_nt * nview_over_nt * (1 - dt * dt);
            if (discriminant >= 0)
            {
                refracted = nview_over_nt * (uv - normal * dt) - normal * (float)Math.Sqrt(discriminant);
                return true;
            }
            else
                return false;
        }
    }
}
