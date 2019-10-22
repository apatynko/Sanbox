using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEnumApp
{
    
    public static class SequenceParser
    {
        
        
        public static List<int> GetSequenceList(string s)
        {
            List<int> list = new List<int>();
            foreach (var el in s.Split(','))
            {
                int number = Int32.Parse(el);
                list.Add(number);
            }

            return list;
        }

        public static string GetSequenceDescription(List<int> ls)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var el in ls)
            {
                switch (el)
                {
                    case 1:
                        sb.Append("1 - Counters\n");
                        break;
                    case 2:
                        sb.Append("2 - Interior floors dry\n");
                        break;
                    case 3:
                        sb.Append("3 - Interior floors wet areas\n");
                        break;
                    case 4:
                        sb.Append("4 - Interior walls dry\n");
                        break;
                    case 5:
                        sb.Append("5 - Interior walls wet\n");
                        break;
                    case 6:
                        sb.Append("6 - Shower floor linear drains\n");
                        break;
                    case 7:
                        sb.Append("7 - Shower Floors\n");
                        break;
                    case 8:
                        sb.Append("8 - Exterior covered walls\n");
                        break;
                    case 9:
                        sb.Append("9 - Exterior walls\n");
                        break;

                    case 10:
                        sb.Append("10 - Exterior paving\n");
                        break;
                    case 11:
                        sb.Append("11 - Pool fountain full lining\n");
                        break;
                    case 12:
                        sb.Append("12 - Pool fountain waterline\n");
                        break;
                    case 13:
                        sb.Append("13 - Tile over tile\n");
                        break;
                    case 14:
                        sb.Append("14 - Furniture\n");
                        break;
                    default:
                        sb.Append(el + " - Unknown ApplicationArea ID\n");
                        break;

                }
            }


            return sb.ToString();
        }

        public static string GetSequenceDestination(List<int> ls)
        {
            bool onWall = false, onFloor = false;

            foreach (var el in ls)
            {
                switch (el)
                {
                    case 1:
                        // 1 - Counters 
                        break;
                    case 2:
                        // 2 - Interior floors dry
                        onFloor = true;
                        break;
                    case 3:
                        // 3 - Interior floors wet areas
                        onFloor = true;
                        break;
                    case 4:
                        // 4 - Interior walls dry
                        onWall = false;
                        break;
                    case 5:
                        // 5 - Interior walls wet
                        onWall = true;
                        break;
                    case 6:
                        // 6 - Shower floor linear drains
                        onFloor = true;
                        break;
                    case 7:
                        // 7 - Shower Floors
                        onFloor = true;
                        break;
                    case 8:
                        // 8 - Exterior covered walls
                        onWall = true;
                        break;
                    case 9:
                        // 9 - Exterior walls
                        onWall = true;
                        break;
                    case 10:
                        // "10 - Exterior paving
                        break;
                    case 11:
                        // 11 - Pool fountain full lining
                        break;
                    case 12:
                        // 12 - Pool fountain waterline
                        break;
                    case 13:
                        // 13 - Tile over tile
                        break;
                    case 14:
                        // 14 - Furniture
                        break;
                    default:
                        //sb.Append(el + " - Unknown ApplicationArea ID\n");
                        break;

                }
            }

            if (onFloor && onWall) return "Wall/Floor";
            if (onWall && !onFloor) return "Wall";
            if (onFloor && !onWall) return "Floor";



            return "undefined";
        }

        public static int GetSequenceApplicationAreaID(List<int> elemenets)
        {
            ApplicationsAreas id = ApplicationsAreas.Undefined;
            bool onInteriorDry = false, onInteriorWet = false;


            foreach (var el in elemenets)
            {
                switch (el)
                {
                    // 1 - Counters
                    case 1:
                        id |= ApplicationsAreas.Counters;
                        break;
                    // 2 - Interior floors dry
                    // 4 - Interior walls dry
                    case 2:
                    case 4:
                        onInteriorDry = true;
                        break;
                    // 3 - Interior floors wet areas
                    // 5 - Interior walls wet
                    case 3:
                    case 5:
                        onInteriorWet = true;
                        break;
                    case 6:
                        // 6 - Shower floor linear drains
                        id |= ApplicationsAreas.ShowerLinearDrains;
                        break;
                    case 7:
                        // 7 - Shower Floors
                        id |= ApplicationsAreas.Shower;
                        break;
                    case 8:
                        // 8 - Exterior covered walls
                        id |= ApplicationsAreas.ExteriorCovered;
                        break;
                    case 9:
                        // 9 - Exterior walls
                        id |= ApplicationsAreas.Exterior;
                        break;
                    case 10:
                        // "10 - Exterior paving
                        id |= ApplicationsAreas.ExteriorPaving;
                        break;
                    case 11:
                        // 11 - Pool fountain full lining
                        id |= ApplicationsAreas.PoolFountainFullLining;
                        break;
                    case 12:
                        // 12 - Pool fountain waterline
                        id |= ApplicationsAreas.PoolFountainWaterline;
                        break;
                    case 13:
                        // 13 - Tile over tile
                        id |= ApplicationsAreas.TileOverTile;
                        break;
                    case 14:
                        // 14 - Furniture
                        id |= ApplicationsAreas.Furniture;
                        break;
                    default:
                        //sb.Append(el + " - Unknown ApplicationArea ID\n");
                        break;

                }
            }

            if (onInteriorDry) id |= ApplicationsAreas.InteriorDry;
            if (onInteriorWet) id |= ApplicationsAreas.InteriorWet;
            return (int)id;

        }

        public static string CreateSequanceApllications(int applicationAreaID, string destination)
        {
            string sequence = string.Empty;
            StringBuilder sb = new StringBuilder();

            ApplicationsAreas appAreasValue = (ApplicationsAreas)applicationAreaID;

            foreach (ApplicationsAreas flagToCheck in Enum.GetValues(typeof(ApplicationsAreas)))
            {
                if (appAreasValue.HasFlag(flagToCheck))
                    switch (flagToCheck)
                {
                    case ApplicationsAreas.Counters:
                        //if (appAreasValue.HasFlag(flagToCheck))
                            sb.Append("1 - Counters\n");
                        break;

                    case ApplicationsAreas.InteriorDry:

                        //if (appAreasValue.HasFlag(flagToCheck))
                        {
                            
                            if (string.Compare(destination, "Wall", 0) == 0)
                                sb.Append("4 - Interior walls dry\n");
                            if (string.Compare(destination, "Floor", 0) == 0)
                                sb.Append("2 - Interior floors dry\n");
                            if (string.Compare(destination, "Wall/Floor", 0) == 0)
                            {
                                sb.Append("2 - Interior floors dry\n");
                                sb.Append("4 - Interior walls dry\n");
                            }
                        }

                        break;


                    case ApplicationsAreas.InteriorWet:
                        //if (appAreasValue.HasFlag(flagToCheck))
                        {
                            if (string.Compare(destination, "Wall", 0) == 0)
                                    sb.Append("5 - Interior walls wet\n");
                            if (string.Compare(destination, "Floor", 0) == 0)
                                    sb.Append("3 - Interior floors wet areas\n");
                            if (string.Compare(destination, "Wall/Floor", 0) == 0)
                                {
                                sb.Append("3 - Interior floors wet areas\n");
                                sb.Append("5 - Interior walls wet\n");
                            }
                        }
                        break;

                    case ApplicationsAreas.ShowerLinearDrains:
                        //if (appAreasValue.HasFlag(flagToCheck))
                            sb.Append("6 - Shower floor linear drains\n");
                        break;

                    case ApplicationsAreas.Shower:
                        //if (appAreasValue.HasFlag(flagToCheck))
                            sb.Append("7 - Shower Floors\n");
                        break;

                    case ApplicationsAreas.ExteriorCovered:
                        //if (appAreasValue.HasFlag(flagToCheck))
                            sb.Append("8 - Exterior covered walls\n");
                        break;

                    case ApplicationsAreas.Exterior:
                        //if (appAreasValue.HasFlag(flagToCheck))
                            sb.Append("9 - Exterior walls\n");
                        break;

                    case ApplicationsAreas.ExteriorPaving:
                        //if (appAreasValue.HasFlag(flagToCheck))
                            sb.Append("10 - Exterior paving\n");
                        break;

                    case ApplicationsAreas.PoolFountainFullLining:
                        //if (appAreasValue.HasFlag(flagToCheck))
                            sb.Append("11 - Pool fountain full lining\n");
                        break;

                    case ApplicationsAreas.PoolFountainWaterline:
                        //if (appAreasValue.HasFlag(flagToCheck))
                            sb.Append("12 - Pool fountain waterline\n");
                        break;

                    case ApplicationsAreas.TileOverTile:
                        //if (appAreasValue.HasFlag(flagToCheck))
                            sb.Append("13 - Tile over tile\n");
                        break;
                    case ApplicationsAreas.Furniture:
                        //if (appAreasValue.HasFlag(flagToCheck))
                            sb.Append("14 - Furniture\n");
                        break;
                    default:
                        break;
                        ;

                }

            }

            return sb.ToString();
        }
    }
}
