using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class PlayerScoreItem
    {
        private int chainModifier;
        
        public int ScoreValue { get; set; }
        
        public String ScoreName { private get; set; }

        override public String ToString()
        {
            return ScoreName.ToString() + "\n" + ScoreValue.ToString();
        }

        public PlayerScoreItem()
        {
            ScoreValue = 0;
            ScoreName = "Score:";
            chainModifier = 1;
        }

        public PlayerScoreItem(String name, int value)
        {
            ScoreName = name;
            ScoreValue = value;
            chainModifier = 1;
        }

        public int ComboValue()
        {
            return chainModifier;
        }
        public void ChainHit()
        {
            chainModifier++;
        }

        public void ResetChain()
        {
            chainModifier = 1;
        }

        public void UpdateScore(int val)
        {
            ScoreValue += val * Chain();
        }
        public void UpdateScoreNoChain(int val)
        {
            ScoreValue += val;
        }

        private int Chain()
        {
            switch(chainModifier)
            {
                case (1):
                    {
                        return 1;
                    }
                case (2):
                    {
                        return 2;
                    }
                case (3):
                    {
                        return 4;
                    }
                case (4):
                    {
                        return 5;
                    }
                case (5):
                    {
                        return 8;
                    }
                case (6):
                    {
                        return 10;
                    }
                case (7):
                    {
                        return 20;
                    }
                case (8):
                    {
                        return 40;
                    }
                case (9):
                    {
                        return 50;
                    }
                case (10):
                    {
                        return 80;
                    }
                default:
                    {
                        return 1;
                    }
            }
        }
    }
}
