using DIPLibrary.CommonTypes;
using System;

namespace DIPLibrary.NormalWay
{
    public class NormalWayApp : IWayApp
    {
        public void ShowExample()
        {
            Console.WriteLine("Welcome to my application!");

            Person owner = new Person()
            {
                FirstName = "Andrew",
                LastName = "Patynko",
                EmailAddress = "andriy.patinko@gmail.com",
                PhoneNumber = "097-934-96-86"
            };

            Chore chore = new Chore
            {
                ChoreName = "Clean all rooms",
                Owner = owner
            };

            chore.PerformedWork(3);
            chore.PerformedWork(1.5);
            chore.CompleteChore();

            Console.ReadLine();
        }
    }
}
