namespace OCPLibrary.NormalWay
{
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public EmployeeType TypeOfEmployee { get; set; } = EmployeeType.Staff;
    }
}