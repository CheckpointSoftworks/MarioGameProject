using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class SmallVineSprite : ISprite
    {
        private Texture2D smallvineSpriteSheet;
        private Vector2 location;
        private AnimatedSprite smallvineSprite;
        private Rectangle collisionRectangle;
        public SmallVineSprite(Vector2 location)
        {
            smallvineSpriteSheet = MiscGameObjectTextureStorage.CreateSmallVineSprite();
            this.location = location;
            smallvineSprite = new AnimatedSprite(smallvineSpriteSheet, UtilityClass.one, UtilityClass.one, location, UtilityClass.one);
            collisionRectangle = smallvineSprite.returnCollisionRectangle();
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            smallvineSprite.Draw(spriteBatch, location, cameraLoc, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
