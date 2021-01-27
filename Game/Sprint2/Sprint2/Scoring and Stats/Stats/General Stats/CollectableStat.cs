using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class CollectableStat : StatItemInt
    {
        public CollectableStat(string name) : base (name)
        {
            StatName = name;
            ResetStatValue();
        }
    }
}
