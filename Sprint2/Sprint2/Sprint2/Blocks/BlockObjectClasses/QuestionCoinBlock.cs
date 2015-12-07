using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class QuestionCoinBlock:IBlock
    {
        private ISprite sprite;
        private BlockType type;
        private bool testForCollision;
        private bool noLongerSpecialized;
        public bool Vine_Box;
        public bool Vine_Dispense;
        private Vector2 location;
        private bool dispenseItemFlag;
        public QuestionCoinBlock(int locX,int locY,BlockType type)
        {
            location = new Vector2(locX, locY);            
            sprite = new QuestionBlockSprite(location);
            this.type = type;
            testForCollision=true;
            Vine_Box = false;
            noLongerSpecialized = false;
            dispenseItemFlag = true;
        }

        public void Update()
        {
            sprite.Update();
            noLongerSpecialized = true;
            if(Vine_Box == true)
            {
                if(dispenseItemFlag==false)
                {
                    Vine_Dispense = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            sprite.Draw(spriteBatch, cameraLoc);
        }

        public BlockType returnBlockType()
        {
            return type;
        }

        public Rectangle returnCollisionRectangle()
        {
            return sprite.returnCollisionRectangle();
        }
        public bool checkForCollisionTestFlag()
        {
            return testForCollision;
        }

        public void removeFromTestingCollision()
        {
            testForCollision = false;
        }

        public bool checkForSpecalizedSideCollision()
        {
            return noLongerSpecialized;
        }
        public void bounceBlock()
        {
            ((QuestionBlockSprite)sprite).bounceSprite();
        }

        public IItemObjects spawnCoin()
        {
            SoundEffectFactory.Coin();
            dispenseItemFlag = false;
            return new BoxCoin((int)location.X, (int)location.Y-UtilityClass.itemOffSet);
        }

        public bool dispenseItem()
        {
            return dispenseItemFlag;
        }
    }
}
