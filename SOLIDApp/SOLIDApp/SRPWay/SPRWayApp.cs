using SOLIDApp.CommonTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDApp.SRPWay
{
    class SPRWayApp : IWayApp
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
