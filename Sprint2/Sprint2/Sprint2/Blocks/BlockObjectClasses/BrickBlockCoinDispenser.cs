using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BrickBlockCoinDispenser:IBlock
    {
        private ISprite sprite;
        private BlockType type;
        private bool testForCollision;
        private bool noLongerSpecialized;
        private bool dispenseCoinFlag;
        private int coinCount;
        private Vector2 location;
        
        public BrickBlockCoinDispenser(int locX,int locY,BlockType type)
        {
            location = new Vector2(locX, locY);
            sprite = new BrickBlockCoinDispenserSprite(location);
            this.type = type;
            dispenseCoinFlag=true;
            testForCollision=true;
            noLongerSpecialized = false;
            coinCount = UtilityClass.CoinDispenserLimit;
        }

        public void Update()
        {
            sprite.Update();
            noLongerSpecialized = true;
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

        public bool coinCounting()
        {
            if (coinCount > 0)
            {
                dispenseCoinFlag=true;
                coinCount--;
            }
            else
            {
                ((BrickBlockCoinDispenserSprite)sprite).outOfCoins();
                dispenseCoinFlag = false;
            }
            return dispenseCoinFlag;
        }

        public IItemObjects dispenseCoin()
        {
            return new BoxCoin((int)location.X, (int)location.Y-UtilityClass.sixteen);
        }

        public void bounceBlock()
        {
            ((BrickBlockCoinDispenserSprite)sprite).bounceSprite();
        }
    }
}
