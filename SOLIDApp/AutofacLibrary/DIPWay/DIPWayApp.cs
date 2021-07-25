using Autofac;
using AutofacLibrary.CommonTypes;
using System;

namespace AutofacLibrary.DIPWay
{
    public class DIPWayApp : IWayApp
    {
        public void ShowExample()
        {
            Console.WriteLine("Welcome to my application!");
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
            Console.ReadLine();
        }
    }
}
