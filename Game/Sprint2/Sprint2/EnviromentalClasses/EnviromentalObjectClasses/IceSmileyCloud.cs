using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class IceSmileyCloud : IEnviromental
    {
        private ISprite IceSmileySprite;
        public IceSmileyCloud(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            IceSmileySprite = new IceSmileyCloudSprite(location);
        }

        public void Update()
        {
            IceSmileySprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            IceSmileySprite.Draw(spriteBatch, cameraLoc);
        }

        public Rectangle returnCollisionRectangle()
        {
            return IceSmileySprite.returnCollisionRectangle();
        }

        public bool testForCollision()
        {
            return true;
        }
    }
}
