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
        private int row;
        private int columns;
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;
        private bool finished;

        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            this.texture = texture;
            this.row = rows;
            this.columns = columns;
            currentFrame = 0;
            totalFrames = row * columns;
        }

        public void Update()
        {
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
        public void Draw(SpriteBatch spriteBatch, Vector2 loc, bool facingRight)
        {
            int width = texture.Width / columns;
            int height = texture.Height / row;
            int rows = (int)((float)currentFrame / (float)columns);
            int col = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(width * col, height * rows, width, height);
            Rectangle destinationRectangle = new Rectangle((int)loc.X, (int)loc.Y, width, height);
            spriteBatch.Begin();
            if (facingRight)
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
            }
            
            spriteBatch.End();
        }

        public bool isFinished()
        {
            return finished;
        }
    }
}

