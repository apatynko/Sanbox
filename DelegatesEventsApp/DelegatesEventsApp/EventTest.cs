using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsApp
{
    class EventTest
    {
        public event EventHandler MyEvent
        {
            add
            {
                Console.WriteLine("add operation");
            }

            remove
            {
                Console.WriteLine("remove operation");
            }
        }

        public static void Run()
        {
            EventTest t = new EventTest();

            t.MyEvent += new EventHandler(t.DoNothing);
            t.MyEvent -= null;
        }

        void DoNothing(object sender, EventArgs e)
        {
        }
    }
}
