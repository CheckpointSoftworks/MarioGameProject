using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public static class AchievementEventTracker
    {
        private static AchievementManager achievementManager;

        public static void setManager(AchievementManager manager)
        {
            achievementManager = manager;
        }
        public static void undergroundAcievement()
        {
            achievementManager.undergroundAchieved();
        }
        public static void killingEnemyAcievement()
        {
            achievementManager.killedEnemyAchieved();
        }
        public static void oneUpAcievement()
        {
            achievementManager.oneUpAchieved();
        }
        public static void superMushAcievement()
        {
            achievementManager.superMushAchieved();
        }
        public static void starAcievement()
        {
            achievementManager.starAchieved();
        }
        public static void fireFlowerAcievement()
        {
            achievementManager.fireFlowerAchieved();
        }
        public static void dyingAcievement()
        {
            achievementManager.dyingAchieved();
        }
        public static void brickSmashedAcievement()
        {
            achievementManager.smashedBrickAchieved();
        }
        public static void hiddenDispenserAcievement()
        {
            achievementManager.coinDispenserAchieved();
        }
        public static void questionCoinAcievement()
        {
            achievementManager.questionCoinAchieved();
        }
        public static void levelFinishAcievement()
        {
            achievementManager.finishedLevelAchieved();
        }
    }
}
