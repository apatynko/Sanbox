using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DesignPatternsAB
{
    class Program
    {
        static void Main(string[] args)
        {
            // Facade
            // FacadeExample facadeExample = new FacadeExample();
            // facadeExample.Run();

            // Singleton
            // HardWorkHelper.DoHardWork();

            // ThreadSafeSingleton
            HardWorkHelper.DoHardWorkThreadSafety();

        }
    }
}
