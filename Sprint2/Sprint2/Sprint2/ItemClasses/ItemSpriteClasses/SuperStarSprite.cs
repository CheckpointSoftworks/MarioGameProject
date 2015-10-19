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
        private AnimatedSprite superStarSprite;
        private Rectangle collisionRectangle;
        public SuperStarSprite(Vector2 location)
        {
            superStarSpriteSheet = ItemSpriteTextureStorage.CreateSuperStarSprite();
            this.location = location;
            superStarSprite = new AnimatedSprite(superStarSpriteSheet, 1, 4, location, 1);
            collisionRectangle = superStarSprite.returnCollisionRectangle();
        }

        public void Update()
        {
            superStarSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            superStarSprite.Draw(spriteBatch, location, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
