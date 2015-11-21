using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class CoinStats : CollectableStat
    {
        public static int TotalAvailable { get; set; }
        public CoinStats(string name)
            : base(name)
        {
            StatName = UtilityClass.CoinName;
        }
        
    }
}
