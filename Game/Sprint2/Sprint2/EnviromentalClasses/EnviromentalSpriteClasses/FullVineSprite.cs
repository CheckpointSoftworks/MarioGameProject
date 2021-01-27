using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class FullVineSprite : ISprite
    {
        private Texture2D FullvineSpriteSheet;
        private Vector2 location;
        private AnimatedSprite FullvineSprite;
        private Rectangle collisionRectangle;
        public FullVineSprite(Vector2 location)
        {
            FullvineSpriteSheet = MiscGameObjectTextureStorage.CreateFullVineSprite();
            this.location = location;
            FullvineSprite = new AnimatedSprite(FullvineSpriteSheet, UtilityClass.one, UtilityClass.one, location, UtilityClass.one);
            collisionRectangle = FullvineSprite.returnCollisionRectangle();
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            FullvineSprite.Draw(spriteBatch, location, cameraLoc, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
