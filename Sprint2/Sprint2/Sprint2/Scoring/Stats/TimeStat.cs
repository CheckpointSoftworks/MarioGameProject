using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    class TimeStat
    {
        private double totalTime;
        private double sessionTime;
        private List<double> deathTimes;
        private List<double> lapTimes;
        public TimeStat(double startingTime)
        {
            totalTime = 0;
            sessionTime = startingTime;
            deathTimes = new List<double>();
            lapTimes = new List<double>();
        }
        public bool UpdateTime(GameTime gameTime)
        {
            totalTime += gameTime.ElapsedGameTime.Milliseconds;
            sessionTime -= gameTime.ElapsedGameTime.TotalSeconds * UtilityClass.timeAdjustment;
            if (sessionTime <= UtilityClass.zero)
            {
                return true;
            }
            return false;
        }

        public void ResetTime()
        {
            deathTimes.Add(totalTime);
            foreach (double t in deathTimes)
            {
                Console.WriteLine("Died at " + (t * Math.Pow(UtilityClass.deltaTime,3)) + " seconds.");
            }
            sessionTime = UtilityClass.LevelStartTime;
        }
        public String FormattedTime()
        {
            return Math.Round(sessionTime, UtilityClass.zero).ToString();
        }
        public void SaveTime()
        {
            lapTimes.Add(sessionTime);
        }
    }
}
