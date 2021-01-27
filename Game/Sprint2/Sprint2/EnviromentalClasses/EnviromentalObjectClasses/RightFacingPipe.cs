using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class RightFacingPipe : IEnviromental
    {
        private ISprite rightfacingpipeSprite;
        public RightFacingPipe(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            rightfacingpipeSprite = new RightFacingPipeSprite(location);
        }

        public void Update()
        {
            rightfacingpipeSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            rightfacingpipeSprite.Draw(spriteBatch, cameraLoc);
        }

        public Rectangle returnCollisionRectangle()
        {
            return rightfacingpipeSprite.returnCollisionRectangle();
        }

        public bool testForCollision()
        {
            return true;
        }
    }
}
