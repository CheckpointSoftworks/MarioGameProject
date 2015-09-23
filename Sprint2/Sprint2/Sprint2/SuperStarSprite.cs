using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class SuperStarSprite : ISprite
    {
        private Texture2D superStarSpriteSheet;
        private Vector2 location;
        private int currentFrame;
        private int totalFrames;
        private int rows;
        private int columns;
        public SuperStarSprite()
        {
            superStarSpriteSheet = ItemSpriteTextureStorage.CreateSuperStarSprite();
            location = new Vector2(500, 100);
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
            int width = superStarSpriteSheet.Width / columns;
            int height = superStarSpriteSheet.Height / rows;
            int row = (int)((float)currentFrame / (float)columns);
            int column = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(superStarSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
