using OCPLibrary.OCPWay.Aplicants;

namespace OCPLibrary.OCPWay.Acounts
{
    public interface IAccounts
    {
        EmployeeModel Create(IApplicantModel person);
    }
}