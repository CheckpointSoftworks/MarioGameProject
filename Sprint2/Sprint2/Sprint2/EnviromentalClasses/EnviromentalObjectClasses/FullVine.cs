using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class FullVine : IEnviromental
    {
        private ISprite FullvineSprite;
        public FullVine(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            FullvineSprite = new FullVineSprite(location);
        }

        public void Update()
        {
            FullvineSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            FullvineSprite.Draw(spriteBatch, cameraLoc);
        }

        public Rectangle returnCollisionRectangle()
        {
            Rectangle dummyrec = new Rectangle(0, 0, 0, 0);
            return dummyrec;
        }

        public bool testForCollision()
        {
            return true;
        }
    }
}
