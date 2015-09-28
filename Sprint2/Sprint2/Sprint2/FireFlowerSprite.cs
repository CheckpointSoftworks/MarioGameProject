using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class FireFlowerSprite : ISprite
    {
        private Texture2D fireFlowerSpriteSheet;
        private Vector2 location;
        private int currentFrame;
        private int totalFrames;
        private int rows;
        private int columns;
        public FireFlowerSprite()
        {
            fireFlowerSpriteSheet = ItemSpriteTextureStorage.CreateFireFlowerSpriteSheet();
            location = new Vector2(100, 100);
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
            int frameWidth = fireFlowerSpriteSheet.Width / columns;
            int frameHeight = fireFlowerSpriteSheet.Height / rows;
            int row = (int)((float)currentFrame / (float)columns);
            int column = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(frameWidth * column, frameHeight * row, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, frameWidth, frameHeight);

            spriteBatch.Begin();
            spriteBatch.Draw(fireFlowerSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
