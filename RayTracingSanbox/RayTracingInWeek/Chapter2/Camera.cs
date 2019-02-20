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
        public Vector3 lower_left_corner;
        public Vector3 horizontal;
        public Vector3 vertical;
        public Vector3 origin;

        public Camera()
        {
            this.lower_left_corner = new Vector3(-2.0f, -1.0f, -1.0f);
            this.horizontal = new Vector3(4.0f, 0.0f, 0.0f);
            this.vertical = new Vector3(0.0f, 2.0f, 0.0f);
            this.origin = new Vector3(0.0f, 0.0f, 0.0f);
        }

        public Ray get_ray(float u, float v)
        {
            return new Ray(origin, lower_left_corner + u*horizontal + v*vertical - origin);
        }
    }
}
