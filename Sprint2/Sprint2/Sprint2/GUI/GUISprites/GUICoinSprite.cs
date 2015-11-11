using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Sprint2
    {
    class GUICoinSprite : ISprite
    {
        private Texture2D coinSpriteSheet;
        private AnimatedSprite coinSprite;
        private Rectangle collisionRectangle;
        private Vector2 location;
        public Vector2 Location
        {
            set { location = value; }
        }
        public GUICoinSprite(Vector2 location)
        {
            coinSpriteSheet = GUISpriteFactory.CreateGUICoinSprite();
            this.location = location;
            coinSprite = new AnimatedSprite(coinSpriteSheet, 1, 4, location, 2);
            collisionRectangle = coinSprite.returnCollisionRectangle();
        }

        public void Update()
        {
            coinSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            coinSprite.Draw(spriteBatch, location, cameraLoc, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
        public int Width()
        {
            return coinSprite.Width();
        }
    }
}


