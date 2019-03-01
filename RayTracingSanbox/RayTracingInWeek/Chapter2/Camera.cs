using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Chapters
{
    class Camera
    {
        public Vector3 origin, lower_left_corner, horizontal, vertical;
        public Vector3 u, v, w;
        float lens_radius;
        public Camera()
        {
            this.lower_left_corner = new Vector3(-2, -1, -1);
            this.horizontal = new Vector3(4, 0, 0);
            this.vertical = new Vector3(0, 2, 0);
            this.origin = new Vector3(0, 0, 0);
        }
        public Camera(Vector3 lookfrom, Vector3 lookat, Vector3 vup, float vfov, float aspect)
        { // vfov is top to bottom in degrees  
            Vector3 u, v, w;
            float theta = (float)(vfov * Math.PI / 180);
            float half_height = (float)Math.Tan(theta / 2);
            float half_width = aspect * half_height;
            this.origin = lookfrom;
            w = Vector3.Normalize(lookfrom - lookat);
            u = Vector3.Normalize(Vector3.Cross(vup, w));
            v = Vector3.Cross(w, u);
            this.lower_left_corner = this.origin - half_width * u - half_height * v - w;
            this.horizontal = 2 * half_width * u;
            this.vertical = 2 * half_height * v;
        }
        public Camera(Vector3 lookfrom, Vector3 lookat, Vector3 vup, float vfov, float aspect, float aperture, float focus_dist)
        {
            lens_radius = aperture / 2;
            float theta = (float)(vfov * Math.PI / 180);
            float half_height = (float)Math.Tan(theta / 2);
            float half_width = aspect * half_height;
            this.origin = lookfrom;
            this.w = Vector3.Normalize(lookfrom - lookat);
            this.u = Vector3.Normalize(Vector3.Cross(vup, w));
            this.v = Vector3.Cross(w, u);
            this.lower_left_corner = this.origin - focus_dist * half_width * u - focus_dist * half_height * v - focus_dist * w;
            this.horizontal = 2 * focus_dist * half_width * u;
            this.vertical = 2 * focus_dist * half_height * v;
        }
        public Ray getRay(float s, float t)
        {
            // The code here should subtract the origin. If don't, when origin is not (0,0,0) it will get wrong result
            return new Ray(this.origin, this.lower_left_corner + s * this.horizontal + t * this.vertical - this.origin);
        }
        public Ray getRayDOF(float s, float t)
        {
            Vector3 rd = lens_radius * random_in_unit_disk();
            Vector3 offset = this.u * rd.X + this.v * rd.Y;
            return new Ray(this.origin + offset, this.lower_left_corner + s * this.horizontal + t * this.vertical - this.origin - offset);
        }


        public static Vector3 random_in_unit_disk()
        {
            Vector3 p;
            Random rdm = new Random(Guid.NewGuid().GetHashCode());
            do
            {
                p = 2 * new Vector3((float)rdm.NextDouble(), (float)rdm.NextDouble(), 0) - new Vector3(1, 1, 0);
            } while (Vector3.Dot(p, p) >= 1.0f);
            return p;
        }
    }
}
