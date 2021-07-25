using AutofacLibrary.CommonTypes;
using System;

namespace AutofacLibrary.NormalWay
{
    public class NormalWayApp : IWayApp
    {
        public void ShowExample()
        {
            Console.WriteLine("Welcome to my application!");
            BusinessLogic businessLogic = new BusinessLogic();

            businessLogic.ProcessData();
            Console.ReadLine();
        }
    }
}
