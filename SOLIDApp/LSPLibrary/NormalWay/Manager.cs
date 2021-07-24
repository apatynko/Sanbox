using System;
using System.Collections.Generic;
using System.Text;

namespace LSPLibrary.NormalWay
{
    class Manager: Employee
    {
        public override void CalculatePerHourRate(int rank)
        {
            decimal baseAmount = 19.75M;

            Salary = baseAmount * (rank * 4);
        }

        public void GeneratePerfomanceReview()
        {
            // Simulate reviewing a direct report here
            Console.WriteLine("I'm reviewing a direct report's perfomance");
        }
    }
}
