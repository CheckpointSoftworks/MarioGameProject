using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class StatItem
    {
        private String statName;
        private int statValue;
        private int defaultValue = 0;
        public String StatName
        {
            get
            {
                return statName;
            }
            set
            {
                statName = value;
            }
        }
        public int StatValue
        {
            get { return statValue; }
            private set { statValue = value; }
        }

        public StatItem(String name)
        {
            StatName = name;
            statValue = defaultValue;
        }
        public StatItem(String name, int defaultValue)
        {
            StatName = name;
            this.defaultValue = defaultValue;
            StatValue = this.defaultValue;
        }

        public void ResetStatValue()
        {
            StatValue = defaultValue;
        }

        public void IncreaseValue(int val)
        {
            StatValue += val;
        }

        public void DecreaseValue(int val)
        {
            StatValue -= val;
        }
    }
}
