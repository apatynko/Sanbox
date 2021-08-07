using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DILifetimeApp
{
    public class SecondCounter : ISecondCounter
    {
        private readonly ICounter _couner;

        public SecondCounter(ICounter counter)
        {
            _couner = counter;
        }

        public int IncrementAndGet()
        {
            _couner.Increment();
            return _couner.Get();
        }
    }
}
