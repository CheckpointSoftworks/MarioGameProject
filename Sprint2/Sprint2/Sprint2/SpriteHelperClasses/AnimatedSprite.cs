using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class AnimatedSprite 
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

        public AnimatedSprite(Texture2D texture, int rows, int columns, Vector2 location, int updatesPerFrame)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            currentFrame = 0;
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
                currentUpdate = 0;
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                    finished = true;
                }
                else if (finished)
                {
                    finished = false;
                }
            }
        }
        

        public void Draw(SpriteBatch spriteBatch, Vector2 loc, bool facingRight)
        {
            int frameRow = (int)((float)currentFrame / (float)columns);
            int frameColumn = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(frameWidth * frameColumn, frameHeight * frameRow, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle((int)loc.X, (int)loc.Y, frameWidth, frameHeight);
            spriteBatch.Begin();
            if (facingRight)
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
            }
            else
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
            }

            spriteBatch.End();
        }

        public bool isFinished()
        {
            return finished;
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

