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
        private AnimatedSprite fireFlowerSprite;
        private Rectangle collisionRectangle;
        private Vector2 location;
        public Vector2 Location
        {
            set { location = value; }
        }
        public FireFlowerSprite(Vector2 location)
        {
            fireFlowerSpriteSheet = ItemSpriteTextureStorage.CreateFireFlowerSprite();
            this.location = location;
            fireFlowerSprite = new AnimatedSprite(fireFlowerSpriteSheet, UtilityClass.one, UtilityClass.generalTotalFramesAndSpecializedRows, location, UtilityClass.two);
            collisionRectangle = fireFlowerSprite.returnCollisionRectangle();
        }

        public void Update()
        {
            fireFlowerSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            fireFlowerSprite.Draw(spriteBatch, location, cameraLoc, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
