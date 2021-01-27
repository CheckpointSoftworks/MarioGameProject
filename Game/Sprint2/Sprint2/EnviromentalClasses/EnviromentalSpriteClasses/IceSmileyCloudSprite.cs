using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class IceSmileyCloudSprite : ISprite
    {
        private Texture2D IceSmileyCloudSpriteSheet;
        private Vector2 location;
        private AnimatedSprite AnimIceSmileyCloud;
        private Rectangle collisionRectangle;
        public IceSmileyCloudSprite(Vector2 location)
        {
            IceSmileyCloudSpriteSheet = MiscGameObjectTextureStorage.CreateIceCloudSprite();
            this.location = location;
            AnimIceSmileyCloud = new AnimatedSprite(IceSmileyCloudSpriteSheet, UtilityClass.one, UtilityClass.one, location, UtilityClass.one);
            collisionRectangle = AnimIceSmileyCloud.returnCollisionRectangle();
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            AnimIceSmileyCloud.Draw(spriteBatch, location, cameraLoc, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
