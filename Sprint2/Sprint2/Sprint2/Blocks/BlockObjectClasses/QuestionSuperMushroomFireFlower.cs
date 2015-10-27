﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class QuestionSuperMushroomFireFlower:IBlock
    {
        private ISprite sprite;
        private BlockType type;
        private bool testForCollision;
        private bool noLongerSpecialized;
        private Vector2 location;
        public QuestionSuperMushroomFireFlower(int locX, int locY, BlockType type)
        {
            location = new Vector2(locX, locY);
            sprite = new QuestionBlockSprite(location);
            this.type = type;
            testForCollision = true;
            noLongerSpecialized = false;
        }

        public void Update()
        {
            sprite.Update();
            noLongerSpecialized = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public BlockType returnBlockType()
        {
            return type;
        }

        public Rectangle returnCollisionRectange()
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

        public IItemObjects spawnSuperMushroom()
        {
            return new SuperMushroom((int)location.X, (int)location.Y-16);
        }

        public IItemObjects spawnFireFlower()
        {
            return new FireFlower((int)location.X, (int)location.Y - 16);
        }
    }
}