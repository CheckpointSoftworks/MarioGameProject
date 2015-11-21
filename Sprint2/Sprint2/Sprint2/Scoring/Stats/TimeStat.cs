using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Sprint2
{
    public class TimeStat
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

        public void ResetTime(bool won)
        {
            if (!won)
            {
                deathTimes.Add(totalTime);
            }
            sessionTime = UtilityClass.LevelStartTime;
        }
        public String FormattedTime()
        {
            return Math.Round(sessionTime, UtilityClass.zero).ToString();
        }
        public void SaveTime()
        {
            lapTimes.Add(UtilityClass.LevelStartTime - sessionTime);
        }

        public void DrawTotals(SpriteBatch spriteBatch, SpriteFont font, Vector2 pos)
        {
            string s = "";
            lapTimes.Sort();
            if (deathTimes.Count == 0)
            {
                s += "Never died!\n";
            }
            foreach (double t in deathTimes)
            {
                s += ("Died at " + (t / 1000) + " seconds\n");
            }
            if (lapTimes.Count == 0)
            {
                s += "Never won!";
            }
            foreach (double t in lapTimes)
            {
                s += "Won in " + Math.Round(t,2) + " seconds\n";
            }
            spriteBatch.DrawString(font, s, pos, Color.White);
        }
    }
}
