using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class PlayerActionStatManager
    {
        private StatItemInt JumpCount { get; set; }
        private StatItemDouble AirTime { get; set; }
        private StatItemInt ShotsFired { get; set; }
        private StatItemInt ShotsHit { get; set; }
        private StatItemInt DamageTaken { get; set; }
        private StatItemDouble TimeSpentInStar { get; set; }
        private StatItemDouble TimeSpentFire { get; set; }
        private StatItemDouble TimeSpentBig { get; set; }

        public PlayerActionStatManager()
        {
            JumpCount = new StatItemInt(UtilityClass.StatJumpName);
            AirTime = new StatItemDouble(UtilityClass.StatAirtimeName);
            ShotsFired = new StatItemInt(UtilityClass.StatShotsFiredName);
            ShotsHit = new StatItemInt(UtilityClass.StatShotsHitName);
            DamageTaken = new StatItemInt(UtilityClass.StatTimesHitName);
            TimeSpentInStar = new StatItemDouble(UtilityClass.StatStarDurationName);
            TimeSpentFire = new StatItemDouble(UtilityClass.StatFireDurationName);
            TimeSpentBig = new StatItemDouble(UtilityClass.StatBigDurationName);
        }

        public void AddJump()
        {
            JumpCount.IncreaseValue(1);
        }

        public void AddAirTime(double t)
        {
            AirTime.IncreaseValue(t);
        }
        public void ShotFired()
        {
            ShotsFired.IncreaseValue(1);
        }
        public void ShotHit()
        {
            ShotsHit.IncreaseValue(1);
        }
        public void ReceivedDamage()
        {
            DamageTaken.IncreaseValue(1);
        }
        public void AddStarTime(double t)
        {
            TimeSpentInStar.IncreaseValue(t);
        }
        public void AddFireTime(double t)
        {
            TimeSpentFire.IncreaseValue(t);
        }
        public void AddBigTime(double t)
        {
            TimeSpentBig.IncreaseValue(t);
        }

        private float ShotAccuracy()
        {
            return (ShotsFired.StatValueInt > 0) ? ((float)ShotsHit.StatValueInt / (float)ShotsFired.StatValueInt) : 0;
        }

        public void PrintAll()
        {
            Console.WriteLine("********** Player Input **********");
            Console.WriteLine(JumpCount.StatName + ": " + JumpCount.StatValueInt);
            Console.WriteLine(AirTime.StatName + ": " + AirTime.StatValueDouble/1000);
            Console.WriteLine(ShotsFired.StatName + ": " + ShotsFired.StatValueInt);
            Console.WriteLine(ShotsHit.StatName + ": " + ShotsHit.StatValueInt);
            Console.WriteLine("Shot accuracy: " + ": " + ShotAccuracy());
            Console.WriteLine(DamageTaken.StatName + ": " + DamageTaken.StatValueInt);
            Console.WriteLine(TimeSpentInStar.StatName + ": " + TimeSpentInStar.StatValueDouble / 1000);
            Console.WriteLine(TimeSpentFire.StatName + ": " + TimeSpentFire.StatValueDouble / 1000);
            Console.WriteLine(TimeSpentBig.StatName + ": " + TimeSpentBig.StatValueDouble / 1000);
        }
        public void DrawTotals(SpriteBatch spriteBatch, SpriteFont font, Vector2 loc)
        {
            string s = UtilityClass.StatSpacing;
            String totals = JumpCount.StatName + s + JumpCount.StatValueInt + "\n" +
             AirTime.StatName + s + AirTime.StatValueDouble / 1000 +" seconds\n" +
             ShotsFired.StatName + s + ShotsFired.StatValueInt + "\n" +
              ShotsHit.StatName + s + ShotsHit.StatValueInt + "\n" +
              UtilityClass.StatShotAccuracyName + s + ShotAccuracy() + "\n" +
              DamageTaken.StatName + s + DamageTaken.StatValueInt + "\n" +
              TimeSpentInStar.StatName + s + TimeSpentInStar.StatValueDouble / 1000 + " seconds\n" +
              TimeSpentFire.StatName + s + TimeSpentFire.StatValueDouble / 1000 + " seconds\n" +
              TimeSpentBig.StatName + s + TimeSpentBig.StatValueDouble / 1000 +" seconds";
            spriteBatch.DrawString(font, totals, loc, Color.White);

        }


    }
}
