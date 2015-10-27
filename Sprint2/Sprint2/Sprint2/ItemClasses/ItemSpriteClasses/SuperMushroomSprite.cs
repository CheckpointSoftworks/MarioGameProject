using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class SuperMushroomSprite : ISprite
    {
        private Texture2D superMushroomSpriteSheet;
        private AnimatedSprite superMushroomSprite;
        private Rectangle collisionRectangle;
        private Vector2 location;
        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }
        public SuperMushroomSprite(Vector2 location)
        {
            superMushroomSpriteSheet = ItemSpriteTextureStorage.CreateSuperMushroomSprite();
            this.location = location;
            superMushroomSprite = new AnimatedSprite(superMushroomSpriteSheet, 1, 1, location, 1);
            collisionRectangle = superMushroomSprite.returnCollisionRectangle();
        }

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            superMushroomSprite.Draw(spriteBatch, location, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
