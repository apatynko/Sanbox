using System;

namespace IoCApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://www.dotnettricks.com/learn/dependencyinjection/understanding-inversion-of-control-dependency-injection-and-service-locator
            //IoCAppNW.NormalWay nw = new IoCAppNW.NormalWay();
            //nw.Demonstarte();

            //IoCAppSL.ServiceLocator sl = new IoCAppSL.ServiceLocator();
            //sl.Demonstarte();

            IoCAppDI.IoCDI di = new IoCAppDI.IoCDI();
            di.Demonstarte();

            Console.ReadKey();
        }
    }
}
