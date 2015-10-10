using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class OneUpMushroomSprite : ISprite
    {
        private Texture2D oneUpMushroomSpriteSheet;
        private Vector2 location;
        private int currentFrame;
        private int rows;
        private int columns;
        private Rectangle collisionRectangle;

        public OneUpMushroomSprite(Vector2 location)
        {
            oneUpMushroomSpriteSheet = ItemSpriteTextureStorage.CreateOneUpMushroomSprite();
            this.location = location;
            currentFrame = 0;
            rows = 1;
            columns = 1;
            int width = oneUpMushroomSpriteSheet.Width / columns;
            int height = oneUpMushroomSpriteSheet.Height / rows;
            collisionRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
        }

        public void Update()
        {
            //No update logic needed
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = oneUpMushroomSpriteSheet.Width / columns;
            int height = oneUpMushroomSpriteSheet.Height / rows;
            int row = (int)((float)currentFrame / (float)columns);
            int column = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(oneUpMushroomSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}