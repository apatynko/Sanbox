using OCPLibrary.OCPWay.Aplicants;

namespace OCPLibrary.OCPWay.Acounts
{
    public class ManagerAccounts : IAccounts
    {
        public EmployeeModel Create(IApplicantModel person)
        {
            EmployeeModel output = new EmployeeModel();
            output.FirstName = person.FirstName;
            output.LastName = person.LastName;
            output.EmailAddress = $"{ person.LastName.Substring(0, 1)}{ person.LastName }@corp.com";
            
            output.IsManager = true;
            
            return output;
        }
    }
}
