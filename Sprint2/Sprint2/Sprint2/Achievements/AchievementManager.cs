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
        private Vector2 displayLocation;
        private SpriteBatch spriteBatch;
        private SpriteFont font;

        public AchievementManager(Vector2 cameraLocation,SpriteBatch spriteBatch,SpriteFont font)
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
            this.spriteBatch = spriteBatch;
            this.font = font;
        }
        //Different Achievement Methods

        //Underground Achievement
        public void undergroundAchieved()
        {
            if (!undergroundAcievement)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(font,"Splunking Time!!!",displayLocation,Color.Black);
                spriteBatch.End();
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
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "Stomp dat Enemy", displayLocation, Color.Black);
                spriteBatch.End();
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
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "BONUS LIFE!", displayLocation, Color.Black);
                spriteBatch.End();
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
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "SUPER SUPER MUSHROOM", displayLocation, Color.Black);
                spriteBatch.End();
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
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "Starshine", displayLocation, Color.Black);
                spriteBatch.End();
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
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "Fire is Fun", displayLocation, Color.Black);
                spriteBatch.End();
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
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "Winner Winner", displayLocation, Color.Black);
                spriteBatch.End();
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
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "Start a New Life", displayLocation, Color.Black);
                spriteBatch.End();
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
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "SMASHED", displayLocation, Color.Black);
                spriteBatch.End();
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
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "Hidden MONIES", displayLocation, Color.Black);
                spriteBatch.End();
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
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "Questions bring Dough", displayLocation, Color.Black);
                spriteBatch.End();
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

        public void updatePopUpBoxPosition(Vector2 location)
        {
            displayLocation.X = location.X;
        }
    }
}
