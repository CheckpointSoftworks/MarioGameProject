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
        private Vector2 location;
        private AnimatedSprite boxCoinSprite;
        private Rectangle collisionRectangle;
        public BoxCoinSprite(Vector2 location)
        {
            boxCoinSpriteSheet = ItemSpriteTextureStorage.CreateBoxCoinSprite();
            this.location = location;
            boxCoinSprite = new AnimatedSprite(boxCoinSpriteSheet, 1, 4, location, 3);
            collisionRectangle = boxCoinSprite.returnCollisionRectangle();
        }

        public void Update()
        {
            boxCoinSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            boxCoinSprite.Draw(spriteBatch, location, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}