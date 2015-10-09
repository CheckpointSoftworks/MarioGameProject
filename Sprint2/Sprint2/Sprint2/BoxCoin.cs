using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BoxCoin : IGameObject
    {
        private ISprite boxCoinSprite;
        public BoxCoin(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            boxCoinSprite = new BoxCoinSprite(location);
        }
        public void Update()
        {
            boxCoinSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            boxCoinSprite.Draw(spriteBatch);
        }
    }
}
