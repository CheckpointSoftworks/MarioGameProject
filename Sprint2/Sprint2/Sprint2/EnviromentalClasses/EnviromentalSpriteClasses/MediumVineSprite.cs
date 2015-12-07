using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class MediumVineSprite : ISprite
    {
        private Texture2D MediumvineSpriteSheet;
        private Vector2 location;
        private AnimatedSprite MediumvineSprite;
        private Rectangle collisionRectangle;
        public MediumVineSprite(Vector2 location)
        {
            MediumvineSpriteSheet = MiscGameObjectTextureStorage.CreateMediumVineSprite();
            this.location = location;
            MediumvineSprite = new AnimatedSprite(MediumvineSpriteSheet, UtilityClass.one, UtilityClass.one, location, UtilityClass.one);
            collisionRectangle = MediumvineSprite.returnCollisionRectangle();
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            MediumvineSprite.Draw(spriteBatch, location, cameraLoc, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
