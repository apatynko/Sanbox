using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEnumApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SequenceMap sequenceMap = new SequenceMap();

            //Console.WriteLine("Max int32 value {0}", int.MaxValue);
            //Console.WriteLine("int.MaxValue > 1310728: {0}", (int.MaxValue > (int)ApplicationsAreas.Furniture).ToString());
            //Console.WriteLine("The output of:");
            //Console.WriteLine("Counters or InteriorFloorsDry or InteriorFloorsWetAreas: {0}",
            //    (int)(ApplicationsAreas.Counters | ApplicationsAreas.InteriorDry | ApplicationsAreas.InteriorWet));
            //var t = (ApplicationsAreas)112;
            //Console.WriteLine("Backward output of 112: {0}", t);

            var seq = "";

            Dictionary<int, string> crossvilleDict = new Dictionary<int, string>()
            {
                {8, "1,2,3,4,5,6,7,8,9,12"},
                {9, "1"},
                {10, "1,2,3,4,5,6,7,9,11,12,14"},
                {11, "1,2,3,4,5,7,8,12"},
                {12, "1,2,3,4,5,8,9"},
                {13, "1,2,3,4,5,8,9,11,12"},
                {14, "1,2,3,4,5,8,9,11,12,7,6"},
                {15, "1,2,3,4,5,9"},
                {16, "1,2,3,4,5,9,11,12,14"},
                {17, "1,2,3,8,9,13"},
                {18, "1,2,4,5,8,9"},
                {19, "1,2,4,5,8,9,11,12"},
                {20, "1,2,4,5,9"},
                {21, "1,2,4,8,9,13"},
                {22, "1,2,4,9"},
                {23, "1,2,4,9,13"},
                {24, "1,3,4,9"},
                {25, "1,4,5"},
                {26, "1,4,5,13"},
                {27, "1,4,5,8,9,12"},
                {28, "1,4,5,9"},
                {29, "1,4,9"},
                {30, "2,3,4,5,8,9,10,11,12"},
                {31, "2,4,5,8,9"},
                {32, "4,5"},
                {33, "4,5,8"},
                {34, "4,5,8,12"},
                {35, "4,5,8,9"},
                {36, "1,2,3,4,5,14"},
                {37, "1,2,4,5,9,11,12"},
                {38, "1,2,3,4,5,9,11,12"},
                {39, "1,2,8,9,13"},
                {40, "1,4,5,8,9,13"},
                {41, "1,2,4,5,8,9,13"}
                
            };
            Console.WriteLine("Enter number between [8, 41] to process variants of the Crossville applications and press [Enter]");
            
            
            //while (true)
            {
                var input = Console.ReadLine();
                 var number = Int16.Parse(input);
                if (number >= 8 && number <= 41)
            {  
               
                    seq = crossvilleDict[number];

                    Console.WriteLine("Sequence: {0}", seq);
                    List<int> ls = SequenceParser.GetSequenceList(seq);
                    Console.WriteLine("Sequence Description:");
                    //Console.WriteLine(SequenceParser.GetSequenceDescription(ls));
                    Console.WriteLine(sequenceMap.GetSequenceByString(seq));
                    Console.WriteLine("Check length: {0}", ls.Count);

                    var appAreaID = SequenceParser.GetSequenceApplicationAreaID(ls);
                    var destination = SequenceParser.GetSequenceDestination(ls);

                    Console.WriteLine("Destination of tile is: {0}", destination);

                    Console.WriteLine("ApplicationAreaID of tile is: {0}", appAreaID);

                    Console.WriteLine("Parsing applicationAreaID: {0} and Destination: {1}", appAreaID, destination);
                    //Console.WriteLine(SequenceParser.CreateSequanceApllications(appAreaID, destination));
                    Console.WriteLine("Result/Comparation:");
                    //Console.WriteLine(sequenceMap.GetSequenceByAppIDAndDestination(appAreaID, destination));
                    Console.WriteLine(sequenceMap.GetSequenceByAppIDAndDestination(appAreaID, "Floor"));
                    Console.WriteLine("Try again or exit.");
                    Console.WriteLine("To exit enter [x].");
                //if (Console.ReadKey().Key == ConsoleKey.X) break;

                }

                else
                {
                    Console.WriteLine("The number is wrong. Try again");
                }
            }

            Console.ReadKey();
        }
    }


}
