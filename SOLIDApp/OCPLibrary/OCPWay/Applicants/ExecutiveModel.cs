using OCPLibrary.OCPWay.Acounts;

namespace OCPLibrary.OCPWay.Aplicants
{
    public class ExecutiveModel : IApplicantModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAccounts AccountProcessor { get; set; } = new ExecutiveAccounts();
    }
}
