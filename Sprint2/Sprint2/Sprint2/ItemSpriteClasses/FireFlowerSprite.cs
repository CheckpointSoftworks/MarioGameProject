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
        private AnimatedSprite fireFlowerSprite;
        private Rectangle collisionRectangle;
        public FireFlowerSprite(Vector2 location)
        {
            fireFlowerSpriteSheet = ItemSpriteTextureStorage.CreateFireFlowerSprite();
            this.location = location;
            fireFlowerSprite = new AnimatedSprite(fireFlowerSpriteSheet, 1, 4, location);
            collisionRectangle = fireFlowerSprite.returnCollisionRectangle();
        }

        public void Update()
        {
            fireFlowerSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            fireFlowerSprite.Draw(spriteBatch, location, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
