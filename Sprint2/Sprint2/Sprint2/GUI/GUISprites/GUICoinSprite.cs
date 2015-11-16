using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Sprint2
    {
    public class GUICoinSprite : ISprite
    {
        private Texture2D coinSpriteSheet;
        private AnimatedSprite coinSprite;
        private Rectangle collisionRectangle;
        private Vector2 location;

        public GUICoinSprite(Vector2 location)
        {
            coinSpriteSheet = GUISpriteFactory.CreateGUICoinSprite();
            this.location = location;
            coinSprite = new AnimatedSprite(coinSpriteSheet, UtilityClass.one, UtilityClass.four, location, UtilityClass.two);
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
    }
}


