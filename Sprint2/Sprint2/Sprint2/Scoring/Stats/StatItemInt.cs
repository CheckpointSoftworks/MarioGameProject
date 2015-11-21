using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class StatItemInt
    {
        private String statName;
        private int statValue;
        private int defaultValue = 0;
        public virtual String StatName
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
        public virtual int StatValue
        {
            get { return statValue; }
            private set { statValue = value; }
        }

        public StatItemInt(String name)
        {
            StatName = name;
            statValue = defaultValue;
        }
        public StatItemInt(String name, int defaultValue)
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
