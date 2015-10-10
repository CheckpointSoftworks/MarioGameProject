using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class SuperMushroomSprite : ISprite
    {
        private Texture2D superMushroomSpriteSheet;
        private Vector2 location;
        private int currentFrame;
        private int rows;
        private int columns;
        private Rectangle collisionRectangle;
        public SuperMushroomSprite(Vector2 location)
        {
            superMushroomSpriteSheet = ItemSpriteTextureStorage.CreateSuperMushroomSprite();
            this.location = location;
            currentFrame = 0;
            rows = 1;
            columns = 1;
            int width = superMushroomSpriteSheet.Width / columns;
            int height = superMushroomSpriteSheet.Height / rows;
            collisionRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
        }

        public void Update()
        {
            //No update logic needed
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = superMushroomSpriteSheet.Width / columns;
            int height = superMushroomSpriteSheet.Height / rows;
            int row = (int)((float)currentFrame / (float)columns);
            int column = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(superMushroomSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
