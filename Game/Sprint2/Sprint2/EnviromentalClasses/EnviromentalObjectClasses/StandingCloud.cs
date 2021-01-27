using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class StandingCloud : IEnviromental
    {
        private ISprite StandingCloudSprite;
        public StandingCloud(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            StandingCloudSprite = new StandingCloudSprite(location);
        }

        public void Update()
        {
            StandingCloudSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            StandingCloudSprite.Draw(spriteBatch, cameraLoc);
        }

        public Rectangle returnCollisionRectangle()
        {
            return StandingCloudSprite.returnCollisionRectangle();
        }

        public bool testForCollision()
        {
            return true;
        }
    }
}
