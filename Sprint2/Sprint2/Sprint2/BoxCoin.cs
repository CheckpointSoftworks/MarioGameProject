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
        public BoxCoin()
        {
            boxCoinSprite = new BoxCoinSprite();
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
