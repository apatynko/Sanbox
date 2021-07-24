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

            //if (person.TypeOfEmployee == EmployeeType.Manager)
            //{
            //    output.IsManager = true;
            //}

            switch (person.TypeOfEmployee)
            {
                case EmployeeType.Staff:
                    break;
                case EmployeeType.Manager:
                    output.IsManager = true;
                    break;
                case EmployeeType.Executive:
                    output.IsManager = true;
                    output.IsExecutive = true;
                    break;
                default:
                    break;
            }

            return output;
        }
    }
}