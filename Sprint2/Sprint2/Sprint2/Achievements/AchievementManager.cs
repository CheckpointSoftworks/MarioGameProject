using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class AchievementManager
    {
        //Set up different Achievement Strings(12)
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
        private Vector2 displayLocation;

        public AchievementManager(Vector2 cameraLocation)
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
            displayLocation = cameraLocation;
        }
        //Different Achievement Methods

        //Underground Achievement
        public void undergroundAchieved()
        {
            if (!undergroundAcievement)
            {
                //Display achievement message
            }
            else
            {
                undergroundAcievement = true;
            }
        }

        //Killing an enemy achievement
        public void killedEnemyAchieved()
        {
            if (!killingEnemyAcievement)
            {
                //Display achievement message
            }
            else
            {
                killingEnemyAcievement = true;
            }
        }

        //Different item achievements(4)
        public void oneUpAchieved()
        {
            if (!oneUpAcievement)
            {
                //Display achievement message
            }
            else
            {
                oneUpAcievement = true;
            }
        }
        public void superMushAchieved()
        {
            if (!superMushAcievement)
            {
                //Display achievement message
            }
            else
            {
                superMushAcievement = true;
            }
        }
        public void starAchieved()
        {
            if (!starAcievement)
            {
                //Display achievement message
            }
            else
            {
                starAcievement = true;
            }
        }
        public void fireFlowerAchieved()
        {
            if (!fireFlowerAcievement)
            {
                //Display achievement message
            }
            else
            {
                fireFlowerAcievement = true;
            }
        }

        //Finishing level achievement
        public void finishedLevelAchieved()
        {
            if (!levelFinishAcievement)
            {
                //Display achievement message
            }
            else
            {
                levelFinishAcievement = true;
            }
        }

        //Dying achievement
        public void dyingAchieved()
        {
            if (!dyingAcievement)
            {
                //Display achievement message
            }
            else
            {
                dyingAcievement = true;
            }
        }

        //Smashing a brick block achievement
        public void smashedBrickAchieved()
        {
            if (!brickSmashedAcievement)
            {
                //Display achievement message
            }
            else
            {
                brickSmashedAcievement = true;
            }
        }

        //Coin block dispenser achievement
        public void coinDispenserAchieved()
        {
            if (!hiddenDispenserAcievement)
            {
                //Display achievement message
            }
            else
            {
                hiddenDispenserAcievement = true;
            }
        }

        //Question block achievement
        public void questionCoinAchieved()
        {
            if (!questionCoinAcievement)
            {
                //Display achievement message
            }
            else
            {
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
