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
        public OneUpMushroom(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            oneUpMushroomSprite = new OneUpMushroomSprite(location);
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
