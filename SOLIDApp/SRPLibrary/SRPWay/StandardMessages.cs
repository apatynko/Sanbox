using System;

namespace SRPLibrary.SRPWay
{
    public class StandardMessages
    {
        public static void SayWelcomeMessage()
        {
            Console.WriteLine("Welcome to my application!");
        }

        public static void EndApplication()
        {
            Console.WriteLine("Please 'Enter' to close the application...");
            Console.ReadKey();
        }

        public static void DisplayValidationError(string fieldName)
        {
            Console.WriteLine($"You did not give us a valid {fieldName}!");
        }
    }
}
