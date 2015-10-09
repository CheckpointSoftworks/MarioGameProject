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
        public SuperMushroomSprite()
        {
            superMushroomSpriteSheet = ItemSpriteTextureStorage.CreateSuperMushroomSprite();
            location = new Vector2(300, 100);
        }

        public void Update()
        {
            //No update needed for the super mushroom
        }

        public void Draw(SpriteBatch spriteBatch)
        {            
            spriteBatch.Begin();
            spriteBatch.Draw(superMushroomSpriteSheet, location, Color.White);
            spriteBatch.End();
        }

        public Rectangle returnCollisionRectangle()
        {
            return new Rectangle(0, 0, 0, 0);
        }
    }
}
