using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class StandingCloudSprite : ISprite
    {
        private Texture2D CloudSpriteSheet;
        private Vector2 location;
        private AnimatedSprite cloudSprite;
        private Rectangle collisionRectangle;
        public StandingCloudSprite(Vector2 location)
        {
            CloudSpriteSheet = MiscGameObjectTextureStorage.CreateStandingCloudSprite();
            this.location = location;
            cloudSprite = new AnimatedSprite(CloudSpriteSheet, UtilityClass.one, UtilityClass.one, location, UtilityClass.one);
            collisionRectangle = cloudSprite.returnCollisionRectangle();
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            cloudSprite.Draw(spriteBatch, location, cameraLoc, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
