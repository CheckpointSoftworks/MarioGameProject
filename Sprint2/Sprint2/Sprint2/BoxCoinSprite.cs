using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class BoxCoinSprite : ISprite
    {
        private Texture2D boxCoinSpriteSheet;
        private Vector2 location;
        private int currentFrame;
        private int totalFrames;
        private int rows;
        private int columns;
        public BoxCoinSprite(Vector2 location)
        {
            boxCoinSpriteSheet = ItemSpriteTextureStorage.CreateBoxCoinSprite();
            this.location = location;
            currentFrame = 0;
            totalFrames = 4;
            rows = 1;
            columns = 4;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = boxCoinSpriteSheet.Width / columns;
            int height = boxCoinSpriteSheet.Height / rows;
            int row = (int)((float)currentFrame / (float)columns);
            int column = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(boxCoinSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle returnCollisionRectangle()
        {
            return new Rectangle(0,0,0,0);
        }
    }
}