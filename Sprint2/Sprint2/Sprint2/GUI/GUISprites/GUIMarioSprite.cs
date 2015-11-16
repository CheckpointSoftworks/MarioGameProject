using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Sprint2
{
    class GUIMarioSprite: ISprite
    {
        private Texture2D guiMarioSpriteSheet;
        private AnimatedSprite guiMarioSprite;
        private Rectangle collisionRectangle;
        private Vector2 location;
        public GUIMarioSprite(Vector2 location)
        {
            guiMarioSpriteSheet = GUISpriteFactory.CreateGUIMarioSprite();
            this.location = location;
            guiMarioSprite = new AnimatedSprite(guiMarioSpriteSheet, UtilityClass.one, UtilityClass.one, location, UtilityClass.two);
            collisionRectangle = guiMarioSprite.returnCollisionRectangle();
        }

        public void Update()
        {
            guiMarioSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            guiMarioSprite.Draw(spriteBatch, location, cameraLoc, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
