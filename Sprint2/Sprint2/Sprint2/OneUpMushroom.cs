using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class OneUpMushroom : IGameObject
    {
        private ISprite oneUpMushroomSprite;
        public OneUpMushroom()
        {
            oneUpMushroomSprite = new OneUpMushroomSprite();
        }
        public void Update()
        {
            oneUpMushroomSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            oneUpMushroomSprite.Draw(spriteBatch);
        }
    }
}
