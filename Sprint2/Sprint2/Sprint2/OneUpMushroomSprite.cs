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
        public OneUpMushroomSprite(Vector2 location)
        {
            oneUpMushroomSpriteSheet = ItemSpriteTextureStorage.CreateOneUpMushroomSprite();
            this.location = location;
        }

        public void Update()
        {
            //No update needed for the super mushroom
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(oneUpMushroomSpriteSheet, location, Color.White);
            spriteBatch.End();
        }
        public Rectangle returnCollisionRectangle()
        {
            return new Rectangle(0,0,0,0);
        }
    }
}