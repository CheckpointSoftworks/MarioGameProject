using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BrickBlockCoinDispenserSprite:ISprite
    {
        private Texture2D brickBlockSpriteSheet;
        private Vector2 location;
        private bool used;
        private Rectangle collisionRectangle;
        private int frame;
        private int spriteSheetSpriteSize;
        private int totalFrames;
        private int bounceTimer;
        private int maxHeight;
        private int minHeight;
        private bool bounce;

        public BrickBlockCoinDispenserSprite(Vector2 location)
        {
            brickBlockSpriteSheet = BlockSpriteTextureStorage.CreateBrickBlockCoinDispenserSprite();
            this.location = location;
            frame = UtilityClass.zero;
            totalFrames = UtilityClass.one;
            used = false;
            bounce = false;
            spriteSheetSpriteSize = brickBlockSpriteSheet.Width / UtilityClass.two;
            bounceTimer = UtilityClass.BlockBounceTimer;
            maxHeight = (int)location.Y - UtilityClass.ten;
            minHeight = (int)location.Y;
            collisionRectangle = new Rectangle((int)location.X, (int)location.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);
        }
        public void Update()
        {
            if (used&&frame<totalFrames)
            {
                frame++;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            dispenserBouncing();
            Rectangle sourceRectangle = sourceRectangle = new Rectangle((spriteSheetSpriteSize*frame), UtilityClass.zero, (spriteSheetSpriteSize), (spriteSheetSpriteSize));
            Rectangle destinationRectangle = new Rectangle((int)location.X - (int)cameraLoc.X, (int)location.Y - (int)cameraLoc.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);

            
            spriteBatch.Draw(brickBlockSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }

        public void outOfCoins()
        {
            used = true;
        }

        public void bounceSprite()
        {
            if (!used)
            {
                bounce = true;
                bounceTimer = UtilityClass.BlockBounceTimer;
            }
        }

        private void dispenserBouncing()
        {

            if (bounceTimer > (UtilityClass.BlockBounceTimer/UtilityClass.two) && bounce)
            {
                int newY = (int)location.Y;
                newY--;
                if (newY > maxHeight)
                {
                    location = new Vector2(location.X, newY);
                }
                bounceTimer--;
            }
            else if (bounce && bounceTimer >= UtilityClass.zero)
            {
                int newY = (int)location.Y;
                newY++;
                if (newY < minHeight)
                {
                    location = new Vector2(location.X, newY);
                }
                bounceTimer--;
            }
            if (used)
            {
                location = new Vector2(location.X, minHeight);
            }
        }
    }
}
