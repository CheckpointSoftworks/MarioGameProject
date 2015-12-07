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
            undergroundAchievementString = UtilityClass.undergroundAchievementString;
            killingEnemyAchievementString = UtilityClass.killingEnemyAchievementString;
            oneUpAchievementString = UtilityClass.oneUpAchievementString;
            superMushAchievementString = UtilityClass.superMushAchievementString;
            starAchievementString=UtilityClass.starAchievementString;
            fireFlowerAchievementString=UtilityClass.fireFlowerAchievementString;
            levelFinishAchievementString=UtilityClass.levelFinishAchievementString;
            dyingAchievementString = UtilityClass.dyingAchievementString;
            brickSmashedAchievementString=UtilityClass.brickSmashedAchievementString;
            hiddenDispenserAchievementString=UtilityClass.hiddenDispenserAchievementString;
            questionCoinAchievementString = UtilityClass.questionCoinAchievementString;
            readInAchievements();
        }

        public void undergroundAchieved()
        {
            if (!undergroundAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), undergroundAchievementString, UtilityClass.earnedAchievementHeader, UtilityClass.zero);
                undergroundAchievement = true;
            }
        }

        public void killedEnemyAchieved()
        {
            if (!killingEnemyAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), killingEnemyAchievementString, UtilityClass.earnedAchievementHeader, UtilityClass.zero);
                killingEnemyAchievement = true;
            }
        }

        public void oneUpAchieved()
        {
            if (!oneUpAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), oneUpAchievementString, UtilityClass.earnedAchievementHeader, UtilityClass.zero);
                oneUpAchievement = true;
            }
        }
        public void superMushAchieved()
        {
            if (!superMushAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), superMushAchievementString, UtilityClass.earnedAchievementHeader, UtilityClass.zero);
                superMushAchievement = true;
            }
        }
        public void starAchieved()
        {
            if (!starAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), starAchievementString, UtilityClass.earnedAchievementHeader, UtilityClass.zero);
                starAchievement = true;
            }
        }

        public void fireFlowerAchieved()
        {
            if (!fireFlowerAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), fireFlowerAchievementString, UtilityClass.earnedAchievementHeader, UtilityClass.zero);
                fireFlowerAchievement = true;
            }

        }

        public void finishedLevelAchieved()
        {
            if (!levelFinishAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), levelFinishAchievementString, UtilityClass.earnedAchievementHeader, UtilityClass.zero);
                levelFinishAchievement = true;
            }
        }

        public void dyingAchieved()
        {
            if (!dyingAchievement)
            {
                MessageBox(new IntPtr(0), dyingAchievementString, UtilityClass.earnedAchievementHeader, UtilityClass.zero);
                dyingAchievement = true;
            }
        }

        public void smashedBrickAchieved()
        {
            if (!brickSmashedAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), brickSmashedAchievementString, UtilityClass.earnedAchievementHeader, UtilityClass.zero);
                brickSmashedAchievement = true;
            }
        }

        public void coinDispenserAchieved()
        {
            if (!hiddenDispenserAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), hiddenDispenserAchievementString, UtilityClass.earnedAchievementHeader, UtilityClass.zero);
                hiddenDispenserAchievement = true;
            }
        }

        public void questionCoinAchieved()
        {
            if (!questionCoinAchievement)
            {
                AchievementPause.Execute();
                MessageBox(new IntPtr(0), questionCoinAchievementString, UtilityClass.earnedAchievementHeader, UtilityClass.zero);
                questionCoinAchievement = true;
            }
        }

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
