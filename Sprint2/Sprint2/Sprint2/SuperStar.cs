using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class SuperStar : IGameObject
    {
        private ISprite superStarSprite;
        public SuperStar(int locX,int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            superStarSprite = new SuperStarSprite(location);
        }
        public void Update()
        {
            superStarSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            superStarSprite.Draw(spriteBatch);
        }

        public Rectangle retrunCollisionRecatangle()
        {
            return superStarSprite.returnCollisionRectangle();
        }
    }
}
