using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsApp
{
    class Program
    {
        static void Main(string[] args)
        {

            DelegateTest.Run();

            EventTest.Run();

            Console.ReadKey();
        }
    }
}
