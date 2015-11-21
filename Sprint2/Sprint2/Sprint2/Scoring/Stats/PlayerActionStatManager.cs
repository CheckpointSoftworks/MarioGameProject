using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            JumpCount = new StatItemInt("Jumps");
            AirTime = new StatItemDouble("Airtime");
            ShotsFired = new StatItemInt("Shots Fired");
            ShotsHit = new StatItemInt("Shots Hit");
            DamageTaken = new StatItemInt("Times hit");
            TimeSpentInStar = new StatItemDouble("Star duration");
            TimeSpentFire = new StatItemDouble("Fire duration");
            TimeSpentBig = new StatItemDouble("Big duration");
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


    }
}
