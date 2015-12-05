using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace Sprint2
{
    public class AchievementManager
    {

        //Set up different Achievement bools(12)
        private bool undergroundAcievement;
        private bool killingEnemyAcievement;
        private bool oneUpAcievement;
        private bool superMushAcievement;
        private bool starAcievement;
        private bool fireFlowerAcievement;
        private bool dyingAcievement;
        private bool brickSmashedAcievement;
        private bool hiddenDispenserAcievement;
        private bool questionCoinAcievement;
        private bool levelFinishAcievement;
        private string undergroundAchievementString;
        private string killingEnemyAcievementString;
        private string oneUpAcievementString;
        private string superMushAcievementString;
        private string starAcievementString;
        private string fireFlowerAcievementString;
        private string dyingAcievementString;
        private string brickSmashedAcievementString;
        private string hiddenDispenserAcievementString;
        private string questionCoinAcievementString;
        private string levelFinishAcievementString;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern uint MessageBox(IntPtr hWnd, String text, String caption, uint type);

        public AchievementManager()
        {
            undergroundAcievement=false;
            killingEnemyAcievement=false;
            oneUpAcievement=false;
            superMushAcievement=false;
            starAcievement=false;
            fireFlowerAcievement=false;
            dyingAcievement=false;
            brickSmashedAcievement=false;
            hiddenDispenserAcievement=false;
            questionCoinAcievement=false;
            levelFinishAcievement=false;
            undergroundAchievementString = "Spelunking Time Achieved";
            killingEnemyAcievementString = "Stomp dat Enemy";
            oneUpAcievementString = "Bonus Life!";
            superMushAcievementString = "Super Mushroom Funtime";
            starAcievementString="STAR TIME";
            fireFlowerAcievementString="FIRE IS FUN!!!";
            levelFinishAcievementString="YOUR THE BEST AROUND";
            dyingAcievementString="Time for a new life.";
            brickSmashedAcievementString="MARIO SMASH";
            hiddenDispenserAcievementString="HIDDEN MONIES!!!!!!";
            questionCoinAcievementString = "Questions bring Dough";
        }
        //Different Achievement Methods

        //Underground Achievement
        public void undergroundAchieved()
        {
            if (!undergroundAcievement)
            {
                MessageBox(new IntPtr(0), undergroundAchievementString, "Achievement Earned", 0);
                undergroundAcievement = true;
            }
        }

        //Killing an enemy achievement
        public void killedEnemyAchieved()
        {
            if (!killingEnemyAcievement)
            {
                MessageBox(new IntPtr(0), killingEnemyAcievementString, "Achievement Earned", 0);
                killingEnemyAcievement = true;
            }
        }

        //Different item achievements(4)
        public void oneUpAchieved()
        {
            if (!oneUpAcievement)
            {
                MessageBox(new IntPtr(0), oneUpAcievementString, "Achievement Earned", 0);
                oneUpAcievement = true;
            }
        }
        public void superMushAchieved()
        {
            if (!superMushAcievement)
            {
                MessageBox(new IntPtr(0), superMushAcievementString, "Achievement Earned", 0);
                superMushAcievement = true;
            }
        }
        public void starAchieved()
        {
            if (!starAcievement)
            {
                MessageBox(new IntPtr(0), starAcievementString, "Achievement Earned", 0);
                starAcievement = true;
            }
        }
        public void fireFlowerAchieved()
        {
            if (!fireFlowerAcievement)
            {
                MessageBox(new IntPtr(0), fireFlowerAcievementString, "Achievement Earned", 0);
                fireFlowerAcievement = true;
            }
        }

        //Finishing level achievement
        public void finishedLevelAchieved()
        {
            if (!levelFinishAcievement)
            {
                MessageBox(new IntPtr(0), levelFinishAcievementString, "Achievement Earned", 0);
                levelFinishAcievement = true;
            }
        }

        //Dying achievement
        public void dyingAchieved()
        {
            if (!dyingAcievement)
            {
                MessageBox(new IntPtr(0), dyingAcievementString, "Achievement Earned", 0);
                dyingAcievement = true;
            }
        }

        //Smashing a brick block achievement
        public void smashedBrickAchieved()
        {
            if (!brickSmashedAcievement)
            {
                MessageBox(new IntPtr(0), brickSmashedAcievementString, "Achievement Earned", 0);
                brickSmashedAcievement = true;
            }
        }

        //Coin block dispenser achievement
        public void coinDispenserAchieved()
        {
            if (!hiddenDispenserAcievement)
            {
                MessageBox(new IntPtr(0), hiddenDispenserAcievementString, "Achievement Earned", 0);
                hiddenDispenserAcievement = true;
            }
        }

        //Question block achievement
        public void questionCoinAchieved()
        {
            if (!questionCoinAcievement)
            {
                MessageBox(new IntPtr(0), questionCoinAcievementString, "Achievement Earned", 0);
                questionCoinAcievement = true;
            }
        }

        //Write achievements to a file
        public void writeOutAchievements(StreamWriter streamWrite)
        {
            if (undergroundAcievement)
            {
                streamWrite.WriteLine(undergroundAchievementString);
            }
            if (killingEnemyAcievement)
            {
                streamWrite.WriteLine(killingEnemyAcievementString);
            }
            if (oneUpAcievement)
            {
                streamWrite.WriteLine(oneUpAcievementString);
            }
            if (superMushAcievement)
            {
                streamWrite.WriteLine(superMushAcievementString);
            }
            if (starAcievement)
            {
                streamWrite.WriteLine(starAcievementString);
            }
            if (fireFlowerAcievement)
            {
                streamWrite.WriteLine(fireFlowerAcievementString);
            }
            if (dyingAcievement)
            {
                streamWrite.WriteLine(dyingAcievementString);
            }
            if (brickSmashedAcievement)
            {
                streamWrite.WriteLine(brickSmashedAcievementString);
            }
            if (hiddenDispenserAcievement)
            {
                streamWrite.WriteLine(hiddenDispenserAcievementString);
            }
            if (questionCoinAcievement)
            {
                streamWrite.WriteLine(questionCoinAcievementString);
            }
            if (levelFinishAcievement)
            {
                streamWrite.WriteLine(levelFinishAcievementString);
            }
        }

        //Read achievements from a file
        public void readInAchievements(StreamReader streamRead)
        {

        }
    }
}
