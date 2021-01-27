using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class SkyWorldBridge : IEnviromental
    {
        private ISprite SkyWorldBridgeSprite;
        public SkyWorldBridge(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            SkyWorldBridgeSprite = new SkyWorldBridgeSprite(location);
        }

        public void Update()
        {
            SkyWorldBridgeSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            SkyWorldBridgeSprite.Draw(spriteBatch, cameraLoc);
        }

        public Rectangle returnCollisionRectangle()
        {
            return SkyWorldBridgeSprite.returnCollisionRectangle();
        }

        public bool testForCollision()
        {
            return true;
        }
    }
}
