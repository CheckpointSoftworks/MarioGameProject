using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class IceFlowerSprite : ISprite
    {
        private Texture2D iceFlowerSpriteSheet;
        private AnimatedSprite iceFlowerSprite;
        private Rectangle collisionRectangle;
        private Vector2 location;
        public Vector2 Location
        {
            set { location = value; }
        }
        public IceFlowerSprite(Vector2 location)
        {
            iceFlowerSpriteSheet = ItemSpriteTextureStorage.CreateIceFlowerSprite();
            this.location = location;
            iceFlowerSprite = new AnimatedSprite(iceFlowerSpriteSheet, UtilityClass.one, UtilityClass.generalTotalFramesAndSpecializedRows, location, UtilityClass.two);
            collisionRectangle = iceFlowerSprite.returnCollisionRectangle();
        }

        public void Update()
        {
            iceFlowerSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            iceFlowerSprite.Draw(spriteBatch, location, cameraLoc, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
