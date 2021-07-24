using SRPLibrary.CommonTypes;
using System;

namespace SRPLibrary.SRPWay
{
   public class PersonDataCapture
    {
        public static Person Capture()
        {
            //Ask for user information

            Person output = new Person();

            Console.WriteLine("What is your first name: ");
            output.FirstName = Console.ReadLine();

            Console.WriteLine("What is your last name: ");
            output.LastName = Console.ReadLine();

            return output;
        }
    }
}
