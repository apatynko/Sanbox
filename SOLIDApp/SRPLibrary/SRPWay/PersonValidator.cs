using SRPLibrary.CommonTypes;

namespace SRPLibrary.SRPWay
{
    public class PersonValidator
    {
        public static bool Validate(Person person)
        {
            //Checks to be sure the first and last names are valid
            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                StandardMessages.DisplayValidationError("first name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                StandardMessages.DisplayValidationError("last name");
                return false;
            }

            return true;
        }
    }
}
