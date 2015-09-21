using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class HiddenBlockSprite : ISprite
    {
        private Texture2D hiddenBlockSpriteSheet;

        public HiddenBlockSprite()
        {
            hiddenBlockSpriteSheet = BlockSpriteTextureStorage.CreateHiddenBlockSprite();
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
