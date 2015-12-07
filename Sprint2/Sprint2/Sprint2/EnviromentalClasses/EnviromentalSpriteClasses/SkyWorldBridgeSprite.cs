using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class SkyWorldBridgeSprite : ISprite
    {
        private Texture2D SkyWorldBridgeSpriteSheet;
        private Vector2 location;
        private AnimatedSprite BridgeSprite;
        private Rectangle collisionRectangle;

        public SkyWorldBridgeSprite(Vector2 location)
        {
            SkyWorldBridgeSpriteSheet = MiscGameObjectTextureStorage.CreateBridgeSprite();
            this.location = location;
            BridgeSprite = new AnimatedSprite(SkyWorldBridgeSpriteSheet, UtilityClass.one, UtilityClass.one, location, UtilityClass.one);
            collisionRectangle = BridgeSprite.returnCollisionRectangle();
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            BridgeSprite.Draw(spriteBatch, location, cameraLoc, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
