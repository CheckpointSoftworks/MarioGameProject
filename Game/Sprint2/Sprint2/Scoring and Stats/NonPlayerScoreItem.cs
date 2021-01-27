using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class NonPlayerScoreItem 
    {
        public bool Chainable { get; private set; }
        public int ScoreValue{ get; set; }
        public NonPlayerScoreItem(int value, bool chain)
        {
            ScoreValue = value;
            Chainable = chain;
        }
    }
}
