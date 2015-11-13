using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class Pipe : IEnviromental
    {
        private ISprite pipeSprite;
        public bool sendunderground = false;
        public Pipe(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            if(sendunderground==false)
            {
                pipeSprite = new PipeSprite(location);
            }
            else
            {
                pipeSprite = new PipeSprite(location, sendunderground);
            }
        }

        public void Update()
        {
            pipeSprite.Update();
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
