using SRPLibrary.CommonTypes;

namespace SRPLibrary.SRPWay
{
    public class SPRWayApp : IWayApp
    {
        public void ShowExample()
        {
            StandardMessages.SayWelcomeMessage();

            Person user = PersonDataCapture.Capture();

            bool isUserValid = PersonValidator.Validate(user);

            if (isUserValid == false)
            {
                StandardMessages.EndApplication();
                return;
            }

            StandardMessages.EndApplication();

            AccountGenerator.CreateAccount(user);
        }
    }
}
