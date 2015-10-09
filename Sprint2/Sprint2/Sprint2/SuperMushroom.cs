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
        public SuperMushroom(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            superMushroomSprite = new SuperMushroomSprite(location);
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
