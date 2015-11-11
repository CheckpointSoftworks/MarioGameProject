using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class BoxCoinSprite : ISprite
    {
        private Texture2D boxCoinSpriteSheet;
        private AnimatedSprite boxCoinSprite;
        private Rectangle collisionRectangle;
        private Vector2 location;
        public Vector2 Location
        {
            set { location = value; }
        }
        public BoxCoinSprite(Vector2 location)
        {
            boxCoinSpriteSheet = ItemSpriteTextureStorage.CreateBoxCoinSprite();
            this.location = location;
            boxCoinSprite = new AnimatedSprite(boxCoinSpriteSheet, UtilityClass.one, UtilityClass.four, location, UtilityClass.three);
            collisionRectangle = boxCoinSprite.returnCollisionRectangle();
        }

        public void Update()
        {
            boxCoinSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            boxCoinSprite.Draw(spriteBatch, location, cameraLoc, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}