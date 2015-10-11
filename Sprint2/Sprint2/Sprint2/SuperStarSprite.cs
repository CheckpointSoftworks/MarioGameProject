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
        private Rectangle collisionRectangle;

        public SuperStarSprite(Vector2 location)
        {
            superStarSpriteSheet = ItemSpriteTextureStorage.CreateSuperStarSprite();
            this.location = location;
            currentFrame = 0;
            totalFrames = 4;
            rows = 1;
            columns = 4;
            int width = superStarSpriteSheet.Width / columns;
            int height = superStarSpriteSheet.Height / rows;
            collisionRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
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

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
