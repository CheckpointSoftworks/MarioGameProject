using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public static class AchievementEventTracker
    {
        private static AchievementManager achievementManager;
        private static bool isRunningTestingClass=true;

        public static void setManager(AchievementManager manager)
        {
            achievementManager = manager;
        }

        public static void endRunningTesting()
        {
            isRunningTestingClass = false;
        }
        public static void undergroundAcievement()
        {
            if (!isRunningTestingClass)
            {
                achievementManager.undergroundAchieved();
            }
        }
        public static void killingEnemyAcievement()
        {
            if (!isRunningTestingClass)
            {
                achievementManager.killedEnemyAchieved();
            }
        }
        public static void oneUpAcievement()
        {
            if (!isRunningTestingClass)
            {
                achievementManager.oneUpAchieved();
            }
        }
        public static void superMushAcievement()
        {
            if (!isRunningTestingClass)
            {
                achievementManager.superMushAchieved();
            }
        }
        public static void starAcievement()
        {
            if (!isRunningTestingClass)
            {
                achievementManager.starAchieved();
            }
        }
        public static void fireFlowerAcievement()
        {
            if (!isRunningTestingClass)
            {
                achievementManager.fireFlowerAchieved();
            }
        }
        public static void dyingAcievement()
        {
            if (!isRunningTestingClass)
            {
                achievementManager.dyingAchieved();
            }
        }
        public static void brickSmashedAcievement()
        {
            if (!isRunningTestingClass)
            {
                achievementManager.smashedBrickAchieved();
            }
        }
        public static void hiddenDispenserAcievement()
        {
            if (!isRunningTestingClass)
            {
                achievementManager.coinDispenserAchieved();
            }
        }
        public static void questionCoinAcievement()
        {
            if (!isRunningTestingClass)
            {
                achievementManager.questionCoinAchieved();
            }
        }
        public static void levelFinishAcievement()
        {
            if (!isRunningTestingClass)
            {
                achievementManager.finishedLevelAchieved();
            }
        }
    }
}
