using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class StatItemDouble : StatItemInt
    {
        private double statDoubleValue;
        private double defaultValue = 0;
        public double StatValueDouble
        {
            get { return statDoubleValue; }
            private set { statDoubleValue = value; }
        }

        public StatItemDouble(String name) : base (name)
        {
            StatName = name;
            statDoubleValue = defaultValue;
        }
        public StatItemDouble(String name, int defaultValue) : base (name, defaultValue)
        {
            StatName = name;
            this.defaultValue = defaultValue;
            StatValueDouble = this.defaultValue;
        }
        public void IncreaseValue(double val)
        {
            StatValueDouble += val;
        }

        public void DecreaseValue(double val)
        {
            StatValueDouble -= val;
        }
    }
}
