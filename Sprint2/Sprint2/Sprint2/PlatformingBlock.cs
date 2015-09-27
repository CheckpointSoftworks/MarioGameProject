using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class PlatformingBlock : IGameObject
    {
        private PlatformingBlockSprite platformingBlockSprite;

        public PlatformingBlock()
        {
            platformingBlockSprite = new PlatformingBlockSprite();
        }

        public void Update()
        {
            platformingBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            platformingBlockSprite.Draw(spriteBatch);
        }
    }
}
