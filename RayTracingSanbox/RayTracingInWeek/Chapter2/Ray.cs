using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Chapters
{
    public class Ray
    {
        public Ray()
        {
            
        }

        public Ray(Vector3 a, Vector3 b)
        {
            A = a;
            B = b;
        }

        public Vector3 Origin()
        {
            return A;
        }

        public Vector3 Direction()
        {
            return B;
        }

        public Vector3 PointAtParameter(float t)
        {
            return A + t*B;
        }

        private Vector3 A;
        private Vector3 B;
    }
}
