using System;
using System.Collections.Generic;
using System.Text;

namespace LSPLibrary.LSPWay
{
    public abstract class BaseEmployee : IEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        public virtual void CalculatePerHourRate(int rank)
        {
            decimal baseAmoumt = 12.50M;
            Salary = baseAmoumt + (rank * 2);
        }
    }
}
