using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class SuperMushroom : IGameObject
    {
        private ISprite superMushroomSprite;
        public SuperMushroom()
        {
            superMushroomSprite = new SuperMushroomSprite();
        }
        public void Update()
        {
            superMushroomSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            superMushroomSprite.Draw(spriteBatch);
        }
    }
}
