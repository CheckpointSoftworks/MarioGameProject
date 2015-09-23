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
            if (totalFrames <= 1)
            {
                currentFrame = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 loc)
        {
            int width = texture.Width / columns;
            int height = texture.Height / row;
            int rows = (int)((float)currentFrame / (float)columns);
            int col = currentFrame % columns;
            Console.WriteLine("Rows: " + rows + " Col: " + col);
            Console.WriteLine("Width: " + width + " Height: " + height);
            //rows = 1;
            //col = 1;
            Rectangle sourceRectangle = new Rectangle(width * col, height * rows, width, height);
            Rectangle destinationRectangle = new Rectangle((int)loc.X, (int)loc.Y, width, height);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public bool isFinished()
        {
            return finished;
        }
    }
}

