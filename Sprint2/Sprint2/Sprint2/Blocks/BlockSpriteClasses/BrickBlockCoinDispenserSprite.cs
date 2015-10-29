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
        private int spriteSheetSpriteSize = 16;
        private int totalFrames;
        private int bounceTimer = 20;
        private int maxHeight;
        private int minHeight;
        private bool bounce;

        public BrickBlockCoinDispenserSprite(Vector2 location)
        {
            brickBlockSpriteSheet = BlockSpriteTextureStorage.CreateBrickBlockCoinDispenserSprite();
            this.location = location;
            frame = 0;
            totalFrames = 1;
            used = false;
            bounce = false;
            maxHeight = (int)location.Y - 10;
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
            if (bounceTimer > 10 && bounce)
            {
                int newY = (int)location.Y;
                newY--;
                if (newY > maxHeight)
                {
                    location = new Vector2(location.X, newY);
                }
                bounceTimer--;
            }
            else if(bounce && bounceTimer >= 0)
            {
                int newY = (int)location.Y;
                newY++;
                if (newY < minHeight)
                {
                    location = new Vector2(location.X, newY);
                }
                bounceTimer--;
            }
            Rectangle sourceRectangle = sourceRectangle = new Rectangle((spriteSheetSpriteSize*frame), 0, (spriteSheetSpriteSize), (spriteSheetSpriteSize));
            Rectangle destinationRectangle = new Rectangle((int)location.X - (int)cameraLoc.X, (int)location.Y - (int)cameraLoc.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);

            spriteBatch.Begin();
            spriteBatch.Draw(brickBlockSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
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
                bounceTimer = 20;
            }
        }
    }
}
