using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class AnimatedSprite : ISprite
    {
        private int rows;
        private int columns;
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;
        private bool finished;
        private int frameWidth;
        private int frameHeight;
        private Rectangle collisionRectangle;
        private Color color;
        private int currentUpdate;
        private int updatesPerFrame;

        public AnimatedSprite(Texture2D inTexture, int rows, int columns, Vector2 location, int updatesPerFrame)
        {
            texture = inTexture;
            this.rows = rows;
            this.columns = columns;
            currentFrame = UtilityClass.zero;
            totalFrames = rows * columns;
            frameWidth = texture.Width / columns;
            frameHeight = texture.Height / rows;
            int width = texture.Width / this.columns;
            int height = texture.Height / this.rows;
            color = Color.White;
            collisionRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
            this.updatesPerFrame = updatesPerFrame;
        }

        public void Update()
        {
            currentUpdate++;
            if (currentUpdate == updatesPerFrame)
            {
                currentUpdate = UtilityClass.zero;
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = UtilityClass.zero;
                    finished = true;
                }
                else if (finished)
                {
                    finished = false;
                }
            }
        }        

        public void Draw(SpriteBatch spriteBatch, Vector2 loc, Vector2 cameraLoc, bool facingRight)
        {
            int frameRow = (int)((float)currentFrame / (float)columns);
            int frameColumn = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(frameWidth * frameColumn, frameHeight * frameRow, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle((int)loc.X - (int)cameraLoc.X, (int)loc.Y - (int)cameraLoc.Y, frameWidth, frameHeight);
            collisionRectangle = destinationRectangle;

            if (facingRight)
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
            }
            else
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, UtilityClass.zero, new Vector2(UtilityClass.zero, UtilityClass.zero), SpriteEffects.FlipHorizontally, UtilityClass.zero);
            }

            collisionRectangle = new Rectangle((int)loc.X, (int)loc.Y, frameWidth, frameHeight);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        { }

        public bool isFinished()
        {
            return finished;
        }

        public int Width()
        {
            return frameWidth;
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }

        public void setColorForDrawing(Color newColor)
        {
            color = newColor;
        }
    }
}

