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
        private int coinCount = 15;
        private Vector2 location;
        
        public BrickBlockCoinDispenser(int locX,int locY,BlockType type)
        {
            location = new Vector2(locX, locY);
            sprite = new BrickBlockCoinDispenserSprite(location);
            this.type = type;
            testForCollision=true;
            noLongerSpecialized = false;
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
            bool dispenseCoin = false;
            if (coinCount > 0)
            {
                dispenseCoin=true;
                coinCount--;
            }
            else
            {
                ((BrickBlockCoinDispenserSprite)sprite).outOfCoins();
            }
            return dispenseCoin;
        }

        public IItemObjects dispenseCoin()
        {
            return new BoxCoin((int)location.X, (int)location.Y);
        }
    }
}
