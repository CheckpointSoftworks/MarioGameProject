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
        public SuperStar()
        {
            superStarSprite = new SuperStarSprite();
        }
        public void Update()
        {
            superStarSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            superStarSprite.Draw(spriteBatch);
        }
    }
}
