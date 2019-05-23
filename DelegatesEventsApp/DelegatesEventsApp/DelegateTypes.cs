using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsApp
{
    class DelegateTypes
    {
    }

    //The first is DelegatesEventsApp.FirstDelegateExample which has a single parameter of type int and returns a string
    public delegate string FirstDelegateExample(int x);

    // The second is DelegatesEventsApp.Sample.SecondDelegateExample
    // which has two char parameters, and doesn't return anything (because the return type is specified as void).
    public class Sample
    {
        public delegate void SecondDelegateExample(char a, char b);
    }
}
