using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class LargeVineSprite : ISprite
    {
        private Texture2D LargevineSpriteSheet;
        private Vector2 location;
        private AnimatedSprite LargevineSprite;
        private Rectangle collisionRectangle;
        public LargeVineSprite(Vector2 location)
        {
            LargevineSpriteSheet = MiscGameObjectTextureStorage.CreateLargeVineSprite();
            this.location = location;
            LargevineSprite = new AnimatedSprite(LargevineSpriteSheet, UtilityClass.one, UtilityClass.one, location, UtilityClass.one);
            collisionRectangle = LargevineSprite.returnCollisionRectangle();
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            LargevineSprite.Draw(spriteBatch, location, cameraLoc, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
