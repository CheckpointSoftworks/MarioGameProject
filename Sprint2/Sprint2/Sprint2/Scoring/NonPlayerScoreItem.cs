using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public NonPlayerScoreItem GetScoreData()
        {
            return new NonPlayerScoreItem(ScoreValue, Chainable);
        }
    }
}
