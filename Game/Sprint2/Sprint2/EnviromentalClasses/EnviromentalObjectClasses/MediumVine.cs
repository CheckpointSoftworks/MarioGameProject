using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class MediumVine : IEnviromental
    {
        private ISprite MediumvineSprite;
        public MediumVine(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            MediumvineSprite = new MediumVineSprite(location);
        }

        public void Update()
        {
            MediumvineSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            MediumvineSprite.Draw(spriteBatch, cameraLoc);
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
