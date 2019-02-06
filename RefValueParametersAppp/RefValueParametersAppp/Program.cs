using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefValueParametersAppp
{
    class Program
    {
        static void FooValue(SampleClass ob)
        {
            SampleClass new_ob = new SampleClass();
            new_ob.x = 5;
            new_ob.y = 5;
            ob = new_ob;
        }

        static void FooReference(ref SampleClass ob)
        {
            SampleClass new_ob = new SampleClass();
            new_ob.x = 5;
            new_ob.y = 5;
            ob = new_ob;
        }

        static SampleClass FooRef(SampleClass ob)
        {
            
            ob.x = 5;
            ob.y = 5;

            return ob;
        }
        static void Main(string[] args)
        {
            SampleClass test = new SampleClass();
            test.x = 1;
            test.y = 1;
            Console.WriteLine("Value x: {0}, value y:{1}", test.x, test.y);
            
            FooValue(test);
            Console.WriteLine("FooValue result. Value x: {0}, value y:{1}", test.x, test.y);

            FooReference(ref test);
            Console.WriteLine("FooReference result. Value x: {0}, value y:{1}", test.x, test.y);

            SampleClass test2 = new SampleClass();
            test2.x = 1;
            test2.y = 1;
            FooRef(test2);
            Console.WriteLine("FooRef result. Value x: {0}, value y:{1}", test2.x, test2.y);


            Console.ReadKey();

        }
    }

    class SampleClass
    {
        public SampleClass()
        {
            
        }

        public int x;
        public int y;
    }
}
