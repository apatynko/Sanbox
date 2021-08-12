using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DILifetimeApp
{
    public class Counter : ICounter
    {
        private int count;

        public void Increment() => count++;

        public int Get()
        {
            return count;
        }
    }
}
