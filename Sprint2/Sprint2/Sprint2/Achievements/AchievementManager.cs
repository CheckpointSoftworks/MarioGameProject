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
        private bool undergroundAchievement;
        private bool killingEnemyAchievement;
        private bool oneUpAchievement;
        private bool superMushAchievement;
        private bool starAchievement;
        private bool fireFlowerAchievement;
        private bool dyingAchievement;
        private bool brickSmashedAchievement;
        private bool hiddenDispenserAchievement;
        private bool questionCoinAchievement;
        private bool levelFinishAchievement;
        private string undergroundAchievementString;
        private string killingEnemyAchievementString;
        private string oneUpAchievementString;
        private string superMushAchievementString;
        private string starAchievementString;
        private string fireFlowerAchievementString;
        private string dyingAchievementString;
        private string brickSmashedAchievementString;
        private string hiddenDispenserAchievementString;
        private string questionCoinAchievementString;
        private string levelFinishAchievementString;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

        public AchievementManager()
        {
            undergroundAchievement=false;
            killingEnemyAchievement=false;
            oneUpAchievement=false;
            superMushAchievement=false;
            starAchievement=false;
            fireFlowerAchievement=false;
            dyingAchievement=false;
            brickSmashedAchievement=false;
            hiddenDispenserAchievement=false;
            questionCoinAchievement=false;
            levelFinishAchievement=false;
            undergroundAchievementString = "Spelunking Time Achieved";
            killingEnemyAchievementString = "Stomp dat Enemy";
            oneUpAchievementString = "Bonus Life!";
            superMushAchievementString = "Super Mushroom Funtime";
            starAchievementString="STAR TIME";
            fireFlowerAchievementString="FIRE IS FUN!!!";
            levelFinishAchievementString="YOUR THE BEST AROUND";
            dyingAchievementString="Time for a new life.";
            brickSmashedAchievementString="MARIO SMASH";
            hiddenDispenserAchievementString="HIDDEN MONIES!!!!!!";
            questionCoinAchievementString = "Questions bring Dough";
            readInAchievements();
        }
        //Different Achievement Methods

        //Underground Achievement
        public void undergroundAchieved()
        {
            if (!undergroundAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), undergroundAchievementString, "Achievement Earned", 0);
                undergroundAchievement = true;
            }
        }

        //Killing an enemy achievement
        public void killedEnemyAchieved()
        {
            if (!killingEnemyAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), killingEnemyAchievementString, "Achievement Earned", 0);
                killingEnemyAchievement = true;
            }
        }

        //Different item achievements(4)
        public void oneUpAchieved()
        {
            if (!oneUpAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), oneUpAchievementString, "Achievement Earned", 0);
                oneUpAchievement = true;
            }
        }
        public void superMushAchieved()
        {
            if (!superMushAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), superMushAchievementString, "Achievement Earned", 0);
                superMushAchievement = true;
            }
        }
        public void starAchieved()
        {
            if (!starAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), starAchievementString, "Achievement Earned", 0);
                starAchievement = true;
            }
        }

        public void fireFlowerAchieved()
        {
            if (!fireFlowerAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), fireFlowerAchievementString, "Achievement Earned", 0);
                fireFlowerAchievement = true;
            }

        }

        //Finishing level achievement
        public void finishedLevelAchieved()
        {
            if (!levelFinishAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), levelFinishAchievementString, "Achievement Earned", 0);
                levelFinishAchievement = true;
            }
        }

        //Dying achievement
        public void dyingAchieved()
        {
            if (!dyingAchievement)
            {
                MessageBox(new IntPtr(0), dyingAchievementString, "Achievement Earned", 0);
                dyingAchievement = true;
            }
        }

        //Smashing a brick block achievement
        public void smashedBrickAchieved()
        {
            if (!brickSmashedAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), brickSmashedAchievementString, "Achievement Earned", 0);
                brickSmashedAchievement = true;
            }
        }

        //Coin block dispenser achievement
        public void coinDispenserAchieved()
        {
            if (!hiddenDispenserAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), hiddenDispenserAchievementString, "Achievement Earned", 0);
                hiddenDispenserAchievement = true;
            }
        }

        //Question block achievement
        public void questionCoinAchieved()
        {
            if (!questionCoinAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), questionCoinAchievementString, "Achievement Earned", 0);
                questionCoinAchievement = true;
            }
        }

        //Write achievements to a file
        public void writeOutAchievements(StreamWriter streamWrite)
        {
            if (undergroundAchievement)
            {
                streamWrite.WriteLine(undergroundAchievementString);
            }
            if (killingEnemyAchievement)
            {
                streamWrite.WriteLine(killingEnemyAchievementString);
            }
            if (oneUpAchievement)
            {
                streamWrite.WriteLine(oneUpAchievementString);
            }
            if (superMushAchievement)
            {
                streamWrite.WriteLine(superMushAchievementString);
            }
            if (starAchievement)
            {
                streamWrite.WriteLine(starAchievementString);
            }
            if (fireFlowerAchievement)
            {
                streamWrite.WriteLine(fireFlowerAchievementString);
            }
            if (dyingAchievement)
            {
                streamWrite.WriteLine(dyingAchievementString);
            }
            if (brickSmashedAchievement)
            {
                streamWrite.WriteLine(brickSmashedAchievementString);
            }
            if (hiddenDispenserAchievement)
            {
                streamWrite.WriteLine(hiddenDispenserAchievementString);
            }
            if (questionCoinAchievement)
            {
                streamWrite.WriteLine(questionCoinAchievementString);
            }
            if (levelFinishAchievement)
            {
                streamWrite.WriteLine(levelFinishAchievementString);
            }
        }

        private void readInAchievements()
        {
            var fileLoc = String.Format("{0}Achievements.txt", AppDomain.CurrentDomain.BaseDirectory);
            FileStream achieveFile = new FileStream(fileLoc, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(achieveFile);
            while (!reader.EndOfStream)
            {
                string nextLine=reader.ReadLine();
                if (nextLine.Equals(undergroundAchievementString))
                {
                    undergroundAchievement = true;
                }
                else if (nextLine.Equals(killingEnemyAchievementString))
                {
                    killingEnemyAchievement = true;
                }
                else if (nextLine.Equals(oneUpAchievementString))
                {
                    oneUpAchievement= true;
                }
                else if (nextLine.Equals(superMushAchievementString))
                {
                    superMushAchievement = true;
                }
                else if (nextLine.Equals(starAchievementString))
                {
                    starAchievement = true;
                }
                else if (nextLine.Equals(fireFlowerAchievementString))
                {
                    fireFlowerAchievement = true;
                }
                else if (nextLine.Equals(dyingAchievementString))
                {
                    dyingAchievement = true;
                }
                else if (nextLine.Equals(brickSmashedAchievementString))
                {
                    brickSmashedAchievement = true;
                }
                else if (nextLine.Equals(hiddenDispenserAchievementString))
                {
                    hiddenDispenserAchievement = true;
                }
                else if (nextLine.Equals(questionCoinAchievementString))
                {
                    questionCoinAchievement = true;
                }
                else if (nextLine.Equals(levelFinishAchievementString))
                {
                    levelFinishAchievement = true;
                }
            }
            reader.Close();
            achieveFile.Close();
        }
    }
}
