using OCPLibrary.OCPWay.Acounts;

namespace OCPLibrary.OCPWay.Aplicants
{
    public interface IApplicantModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        IAccounts AccountProcessor { get; set; }
    }
}