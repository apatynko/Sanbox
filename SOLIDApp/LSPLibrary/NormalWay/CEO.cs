using System;
using System.Collections.Generic;
using System.Text;

namespace LSPLibrary.NormalWay
{
    public class CEO: Employee
    {
        public override void CalculatePerHourRate(int rank)
        {
            decimal baseAmoumt = 150M;
            Salary = baseAmoumt * rank;
        }

        public override void AssignManager(Employee manager)
        {
            throw new InvalidOperationException("The CEO has no manager");
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
