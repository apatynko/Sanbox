using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEnumApp
{
    public class SequenceMap
    {
        Dictionary<int, string> m_sequenceMap = new Dictionary<int, string>()
        {
            {1, "Counters"},
            {2, "Interior floors dry"},
            {3, "Interior floors wet areas"},
            {4, "Interior walls dry"},
            {5, "Interior walls wet"},
            {6, "Shower floor linear drains"},
            {7, "Shower Floors"},
            {8, "Exterior covered walls"},
            {9, "Exterior walls"},
            {10, "Exterior paving"},
            {11, "Pool fountain full lining"},
            {12, "Pool fountain waterline"},
            {13, "Tile over tile"},
            {14, "Furniture"}
        };

        Dictionary<ApplicationsAreas, int> m_sequenceMapAppAreas = new Dictionary<ApplicationsAreas, int>()
        {
            {ApplicationsAreas.Counters, 1},
            {ApplicationsAreas.InteriorDryFloor, 2},
            {ApplicationsAreas.InteriorWetFloor, 3},
            {ApplicationsAreas.InteriorDryWall, 4},
            {ApplicationsAreas.InteriorWetWall, 5},
            {ApplicationsAreas.ShowerLinearDrains, 6},
            {ApplicationsAreas.Shower, 7},
            {ApplicationsAreas.ExteriorCovered, 8},
            {ApplicationsAreas.Exterior, 9},
            {ApplicationsAreas.ExteriorPaving, 10},
            {ApplicationsAreas.PoolFountainFullLining, 11},
            {ApplicationsAreas.PoolFountainWaterline, 12},
            {ApplicationsAreas.TileOverTile, 13},
            {ApplicationsAreas.Furniture, 14}
        };

        public SequenceMap()
        {

        }



        /// <summary>
        /// Get single item from all map by int key 
        /// </summary>
        /// <param name="key"></param>
        /// <returns>string with key and description</returns>
        internal string GetSequenceMapKey(int key)
        {
            if (!m_sequenceMap.ContainsKey(key))
            {
                return key + " - Does not exist!!!";
            }
            return key + " - " + m_sequenceMap[key];

        }

        internal string GetSequenceMapAllItems()
        {
            var sb = new StringBuilder();
            foreach (var key in m_sequenceMap.Keys)
            {
                sb.Append(GetSequenceMapKey(key));
                sb.AppendLine();
            }

            return sb.ToString();
        }

        internal string GetSequenceByString(string sequenceString)
        {
            List<int> keys = SequenceParser.GetSequenceList(sequenceString);
            StringBuilder sb = new StringBuilder();
            foreach (var key in keys)
            {
                sb.Append(GetSequenceMapKey(key));
                sb.AppendLine();
            }

            return sb.ToString();
        }

        internal string GetSequenceByKeys(List<int> keys)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var key in keys)
            {
                sb.Append(GetSequenceMapKey(key));
                sb.AppendLine();
            }
            return sb.ToString();
        }

        int GetSeqKey(ApplicationsAreas flagToCheck)
        {
            int key;
            key = m_sequenceMapAppAreas[flagToCheck];
            
            return key;

        }

        internal string GetSequenceByAppIDAndDestination(int applicationAreaID, string destination)
        {
            string sequence = string.Empty;
            var keys = new List<int>();

            ApplicationsAreas appAreasValue = (ApplicationsAreas)applicationAreaID;

            foreach (ApplicationsAreas flagToCheck in Enum.GetValues(typeof(ApplicationsAreas)))
            {
                if (appAreasValue.HasFlag(flagToCheck))
                    switch (flagToCheck)
                    {
                        case ApplicationsAreas.Counters:
                        case ApplicationsAreas.ShowerLinearDrains:
                        case ApplicationsAreas.Shower:
                        case ApplicationsAreas.ExteriorCovered:
                        case ApplicationsAreas.Exterior:
                        case ApplicationsAreas.ExteriorPaving:
                        case ApplicationsAreas.PoolFountainFullLining:
                        case ApplicationsAreas.PoolFountainWaterline:
                        case ApplicationsAreas.TileOverTile:
                        case ApplicationsAreas.InteriorDryFloor:
                        case ApplicationsAreas.InteriorWetFloor:
                        case ApplicationsAreas.InteriorDryWall:
                        case ApplicationsAreas.InteriorWetWall:
                        case ApplicationsAreas.Furniture:
                            //keys.Add(1);
                            keys.Add(GetSeqKey(flagToCheck));

                            break;

                        //case ApplicationsAreas.InteriorDry:
                        //case ApplicationsAreas.InteriorWet:
                        //    {

                        //        if (string.Compare(destination, "Wall", 0) == 0)
                        //        {
                        //            //keys.Add(4);
                        //            keys.Add(GetSeqKey(flagToCheck) + 2); // TODO temporal; destination defines the final key.
                        //        }

                        //        if (string.Compare(destination, "Floor", 0) == 0)
                        //        {
                        //                //keys.Add(2);
                        //            keys.Add(GetSeqKey(flagToCheck));
                        //            }
                        //        if (string.Compare(destination, "Wall/Floor", 0) == 0)
                        //        {
                        //            //keys.Add(2);
                        //            //keys.Add(4);
                        //            keys.Add(GetSeqKey(flagToCheck));
                        //            keys.Add(GetSeqKey(flagToCheck) +2); // TODO temporal; destination defines the final key.
                        //        }
                        //    }
                        //    break;


                        //case ApplicationsAreas.InteriorWet:
                        //    {
                        //        if (string.Compare(destination, "Wall", 0) == 0)
                        //        {
                        //            //keys.Add(5);
                        //            keys.Add(GetSeqKey(flagToCheck) + 2);
                        //        }
                        //        if (string.Compare(destination, "Floor", 0) == 0)
                        //        {
                        //            //keys.Add(3);
                        //            keys.Add(GetSeqKey(flagToCheck));
                        //        }
                        //        if (string.Compare(destination, "Wall/Floor", 0) == 0)
                        //        {
                        //            //keys.Add(3);
                        //            //keys.Add(5);
                        //            keys.Add(GetSeqKey(flagToCheck));
                        //            keys.Add(GetSeqKey(flagToCheck) + 2);
                        //        }
                        //    }
                        //    break;

                        //case ApplicationsAreas.ShowerLinearDrains:
                        //    //keys.Add(6);
                        //    keys.Add(GetSeqKey(flagToCheck));
                        //    break;

                        //case ApplicationsAreas.Shower:
                        //    //keys.Add(7);
                        //    keys.Add(GetSeqKey(flagToCheck));
                        //    break;

                        //case ApplicationsAreas.ExteriorCovered:
                        //    //keys.Add(8);
                        //    keys.Add(GetSeqKey(flagToCheck));
                        //    break;

                        //case ApplicationsAreas.Exterior:
                        //    //keys.Add(9);
                        //    keys.Add(GetSeqKey(flagToCheck));
                        //    break;

                        //case ApplicationsAreas.ExteriorPaving:
                        //    //keys.Add(10);
                        //    keys.Add(GetSeqKey(flagToCheck));
                        //    break;

                        //case ApplicationsAreas.PoolFountainFullLining:
                        //    //keys.Add(11);
                        //    keys.Add(GetSeqKey(flagToCheck));
                        //    break;

                        //case ApplicationsAreas.PoolFountainWaterline:
                        //    //keys.Add(12);
                        //    keys.Add(GetSeqKey(flagToCheck));
                        //    break;

                        //case ApplicationsAreas.TileOverTile:
                        //    //keys.Add(13);
                        //    keys.Add(GetSeqKey(flagToCheck));
                        //    break;
                        //case ApplicationsAreas.Furniture:
                        //    //keys.Add(14);
                        //    keys.Add(GetSeqKey(flagToCheck));
                        //    break;
                        default:
                            break;
                    }

            }
            keys.Sort();
            sequence = GetSequenceByKeys(keys);
            sequence += "\n";
            sequence += "check count: " + keys.Count;
            return sequence;
        }
    }
}
