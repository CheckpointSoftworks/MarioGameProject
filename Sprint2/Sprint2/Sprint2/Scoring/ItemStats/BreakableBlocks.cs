using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BreakableBlockStats : CollectableStat
    {
        public static int TotalAvailable { get; set; }
        public BreakableBlockStats(string name)
            : base(name)
        {
            StatName = "BreakableBlocks";
        }

        //Temporary, plz to delete thx
        public static void HowMany()
        {
            Console.WriteLine("BreakableBlocks: " + TotalAvailable);

        }
    }
}
