using DIPLibrary.CommonTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIPLibrary.DIPWay
{
    public class DIPWayApp : IWayApp
    {
        public void ShowExample()
        {
            Console.WriteLine("Welcome to my application!");

            IPerson owner = Factory.CreatePerson();

            owner.FirstName = "Andrew";
            owner.LastName = "Patynko";
            owner.EmailAddress = "andriy.patinko@gmail.com";
            owner.PhoneNumber = "097-934-96-86";

            IChore chore = Factory.CreateChore();

            chore.ChoreName = "Clean all rooms";
            chore.Owner = owner;


            chore.PerformedWork(3);
            chore.PerformedWork(1.5);
            chore.CompleteChore();

            Console.ReadLine();
        }
    }
}
