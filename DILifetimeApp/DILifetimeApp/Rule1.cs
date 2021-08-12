using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DILifetimeApp
{
    public class Rule1 : IRule
    {
        private bool _isActive;
        public bool IsActive { get => _isActive; }

        public void Enable()
        {
            _isActive = true;
        }

        public void Disable()
        {
            _isActive = false;
        }

    }
}
