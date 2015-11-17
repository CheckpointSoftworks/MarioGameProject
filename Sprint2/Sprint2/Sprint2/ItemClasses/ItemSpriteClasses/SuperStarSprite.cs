using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class SuperStarSprite : ISprite
    {
        private Texture2D superStarSpriteSheet;
        private Vector2 location;
        private AnimatedSprite superStarSprite;

        public SuperStarSprite(Vector2 location)
        {
            superStarSpriteSheet = ItemSpriteTextureStorage.CreateSuperStarSprite();
            this.location = location;
            superStarSprite = new AnimatedSprite(superStarSpriteSheet, UtilityClass.one, UtilityClass.generalTotalFramesAndSpecializedRows, location, UtilityClass.one);
        }

        public void Update()
        {
            superStarSprite.Update();
        }
        public void Update(Vector2 loc)
        {
            
            location = loc;
            superStarSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            superStarSprite.Draw(spriteBatch, location, cameraLoc, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return superStarSprite.returnCollisionRectangle();
        }
    }
}
