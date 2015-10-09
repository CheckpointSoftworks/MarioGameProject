using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class GroundBlock : IBlock
    {
        private ISprite groundBlockSprite;
        public GroundBlock(Vector2 location)
        {
            groundBlockSprite = new GroundBlockSprite(location);
        }
        public void Update()
        {
            groundBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            groundBlockSprite.Draw(spriteBatch);
        }

        public Rectangle  returnCollisionRectange()
        {
            return groundBlockSprite.returnCollisionRectangle();
        }
    }
}
