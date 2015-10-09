using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class HiddenBlock : IBlock
    {
        private ISprite hiddenBlockSprite;
        public HiddenBlock(Vector2 location)
        {
            hiddenBlockSprite = new HiddenBlockSprite(location);
        }
        public void Update()
        {
            hiddenBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            hiddenBlockSprite.Draw(spriteBatch);
        }
        public Rectangle returnCollisionRectange()
        {
            return hiddenBlockSprite.returnCollisionRectangle();
        }
    }
}
