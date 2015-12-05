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
        }
        //Different Achievement Methods

        //Underground Achievement
        public void undergroundAchieved()
        {
            if (!undergroundAcievement)
            {
                MessageBox(new IntPtr(0), "Spelunking Time Achieved", "Achievement", 0);
                undergroundAcievement = true;
            }
        }

        //Killing an enemy achievement
        public void killedEnemyAchieved()
        {
            if (!killingEnemyAcievement)
            {
                MessageBox(new IntPtr(0), "Stomp dat Enemy", "Achievement", 0);
                killingEnemyAcievement = true;
            }
        }

        //Different item achievements(4)
        public void oneUpAchieved()
        {
            if (!oneUpAcievement)
            {
                MessageBox(new IntPtr(0), "Bonus Life!", "Achievement", 0);
                oneUpAcievement = true;
            }
        }
        public void superMushAchieved()
        {
            if (!superMushAcievement)
            {
                MessageBox(new IntPtr(0), "Super Mushroom Funtime", "Achievement", 0);
                superMushAcievement = true;
            }
        }
        public void starAchieved()
        {
            if (!starAcievement)
            {
                MessageBox(new IntPtr(0), "STAR TIME", "Achievement", 0);
                starAcievement = true;
            }
        }
        public void fireFlowerAchieved()
        {
            if (!fireFlowerAcievement)
            {
                MessageBox(new IntPtr(0), "FIRE IS FUN!!!", "Achievement", 0);
                fireFlowerAcievement = true;
            }
        }

        //Finishing level achievement
        public void finishedLevelAchieved()
        {
            if (!levelFinishAcievement)
            {
                MessageBox(new IntPtr(0), "YOUR THE BEST AROUND", "Achievement", 0);
                levelFinishAcievement = true;
            }
        }

        //Dying achievement
        public void dyingAchieved()
        {
            if (!dyingAcievement)
            {
                MessageBox(new IntPtr(0), "Time for a new life.", "Achievement", 0);
                dyingAcievement = true;
            }
        }

        //Smashing a brick block achievement
        public void smashedBrickAchieved()
        {
            if (!brickSmashedAcievement)
            {
                MessageBox(new IntPtr(0), "MARIO SMASH", "Achievement", 0);
                brickSmashedAcievement = true;
            }
        }

        //Coin block dispenser achievement
        public void coinDispenserAchieved()
        {
            if (!hiddenDispenserAcievement)
            {
                MessageBox(new IntPtr(0), "HIDDEN MONIES!!!!!!", "Achievement", 0);
                hiddenDispenserAcievement = true;
            }
        }

        //Question block achievement
        public void questionCoinAchieved()
        {
            if (!questionCoinAcievement)
            {
                MessageBox(new IntPtr(0), "Questions bring Dough", "Achievement", 0);
                questionCoinAcievement = true;
            }
        }

        //Write achievements to a file
        public void writeOutAchievements(StreamWriter streamWrite)
        {

        }

        //Read achievements from a file
        public void readInAchievements(StreamReader streamRead)
        {

        }
    }
}
