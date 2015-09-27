using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class HiddenBlock : IGameObject
    {
        private HiddenBlockSprite hiddenBlockSprite;

        public HiddenBlock()
        {
            hiddenBlockSprite = new HiddenBlockSprite();
        }

        public void Update()
        {
            hiddenBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            hiddenBlockSprite.Draw(spriteBatch);
        }
    }
}
