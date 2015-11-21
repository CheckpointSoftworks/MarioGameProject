using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class SuperStarStats : CollectableStat
    {
        public static int TotalAvailable { get; set; }
        public SuperStarStats(string name)
            : base(name)
        {
            StatName = UtilityClass.SuperStarName;
        }
    }
}
