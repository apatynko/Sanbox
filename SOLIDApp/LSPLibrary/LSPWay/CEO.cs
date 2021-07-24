using System;
using System.Collections.Generic;
using System.Text;

namespace LSPLibrary.LSPWay
{
    public class CEO: BaseEmployee, IManager
    {
        public override void CalculatePerHourRate(int rank)
        {
            decimal baseAmoumt = 150M;
            Salary = baseAmoumt * rank;
        }       

        public void GeneratePerfomanceReview()
        {
            // Simulate reviewing a direct report
            Console.WriteLine("I'm reviewing a direct report's perfomance.");
        }

        public void FireSomeone()
        {
            Console.WriteLine("You're Fired!");
        }
    }
}
