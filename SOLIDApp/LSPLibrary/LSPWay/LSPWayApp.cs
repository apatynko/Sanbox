using System;
using LSPLibrary.CommonTypes;

namespace LSPLibrary.LSPWay
{
    public class LSPWayApp : IWayApp
    {
        public void ShowExample()
        {
            IManager accountingVP = new CEO();

            accountingVP.FirstName = "Emma";
            accountingVP.LastName = "Stone";
            accountingVP.CalculatePerHourRate(4);

            BaseEmployee emp = new Employee();

            emp.FirstName = "Tim";
            emp.LastName = "Corey";
            //emp.AssignManager(accountingVP);
            emp.CalculatePerHourRate(2);

            Console.WriteLine($" { emp.FirstName }'s salary is { emp.Salary }/hour.");

            Console.ReadLine();
        }
    }
}
