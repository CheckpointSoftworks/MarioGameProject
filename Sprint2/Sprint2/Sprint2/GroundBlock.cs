using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class GroundBlock : IGameObject
    {
        private ISprite groundBlockSprite;
        public GroundBlock()
        {
            groundBlockSprite = new GroundBlockSprite();
        }
        public void Update()
        {
            groundBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            groundBlockSprite.Draw(spriteBatch);
        }
    }
}
