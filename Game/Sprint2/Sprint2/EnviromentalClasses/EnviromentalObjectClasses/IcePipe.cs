using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class IcePipe : IEnviromental
    {
        private ISprite pipeSprite;
        private bool sendunderground = false;
        public IcePipe(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            if (sendunderground == false)
            {
                pipeSprite = new IcePipeSprite(location);
            }
            else
            {
                pipeSprite = new IcePipeSprite(location);
            }
        }

        public void Update()
        {
            pipeSprite.Update();
        }
        public void setUnderground()
        {
            sendunderground = true;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            pipeSprite.Draw(spriteBatch, cameraLoc);
        }

        public Rectangle returnCollisionRectangle()
        {
            return pipeSprite.returnCollisionRectangle();
        }

        public bool testForCollision()
        {
            return true;
        }
    }
}
