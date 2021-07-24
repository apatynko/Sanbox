using System;

namespace OCPLibrary.NormalWay
{
    public class Accounts
    {
        public EmployeeModel Create(PersonModel person)
        {
            EmployeeModel output = new EmployeeModel();
            output.FirstName = person.FirstName;
            output.LastName = person.LastName;
            output.EmailAddress = $"{ person.LastName.Substring(0, 1 )}{ person.LastName }@example.com";

            return output;
        }
    }
}