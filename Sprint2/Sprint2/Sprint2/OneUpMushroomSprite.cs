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
        private bool pickedUp;
        public OneUpMushroomSprite(Vector2 location)
        {
            oneUpMushroomSpriteSheet = ItemSpriteTextureStorage.CreateOneUpMushroomSprite();
            this.location = location;
            currentFrame = 0;
            rows = 1;
            columns = 2;
            pickedUp = false;
        }

        public void Update()
        {
            if (pickedUp == false)
            {
                currentFrame = 0;
            }
            else
            {
                currentFrame = 1;
            }
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
            return new Rectangle(0,0,0,0);
        }
    }
}