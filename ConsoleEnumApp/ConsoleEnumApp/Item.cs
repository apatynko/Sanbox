using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEnumApp
{
    public class Item
    {
        private Destinations Destination => Destinations.Undefined;
        private ApplicationsAreas ApplicationsAreas => ApplicationsAreas.Undefined;

        public Item()
        {

        }

    }

    public enum UsageAreas
    {
        Undefined = 0,
        Bathroom = 1,
        Livingroom = 2,
        Kitchen = 3,
        Pool = 4,
        PublicArea = 5,
        Exterior = 6


    }


    public enum Destinations
    {
        Undefined = 0,
        Wall = 2,       //Wall
        Floor = 3,      //Floor
        WallFloor = 4,  //WallFloor
        Stairs = 5,     //Stairs
        Edge = 6,       //Tile for edge
        Ceiling = 7     //Ceiling
    }


    [Flags]
    public enum ApplicationsAreas
    {
        Undefined = 0,
        Bathroom =               1 << 0,
        LivingRoom =             1 << 1,
        Kitchen =                1 << 2,
        Pool =                   1 << 3,
        PublicArea =             1 << 4,
        Exterior =               1 << 5,
        Counters =               1 << 6,
        InteriorDryFloor =       1 << 7,
        InteriorWetFloor =       1 << 8,
        InteriorDryWall =        1 << 9,
        InteriorWetWall =        1 << 10,
        ShowerLinearDrains =     1 << 11,
        Shower =                 1 << 12,
        ExteriorCovered =        1 << 13,
        ExteriorPaving =         1 << 14,
        PoolFountainFullLining = 1 << 15,
        PoolFountainWaterline =  1 << 16,
        TileOverTile =           1 << 17,
        Furniture =              1 << 18

    }

    [Flags]
    public enum UsageApplications
    {
        Undefined = 0,
        Bathroom = 1,
        Livingroom = 2,
        Kitchen = 4,
        Pool = 8,
        PublicArea = 16,
        Exterior = 32,

        Counters = 64,
        InteriorDry = 128,
        InteriorWet = 256,
        InteriorWetAreas = 512,
        ShowerLinearDrains = 1024,
        Shower = 2048,

        ExteriorCovered = 4096,
        //Exterior
        ExteriorPaving = 8192,

        PoolFountainFullLining = 16384,
        PoolFountainWaterline = 32768,

        TileOverTile = 65536,
        Furniture = 131072

    }
}
