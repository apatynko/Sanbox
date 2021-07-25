using System;
using System.Collections.Generic;
using System.Text;

namespace DIPLibrary.DIPWay
{
    public class Texter : IMessageCenter
    {
        public void SendMessage(IPerson person, string message)
        {
            Console.WriteLine($"I am texting { person.FirstName } to say { message }");
        }
    }
}
