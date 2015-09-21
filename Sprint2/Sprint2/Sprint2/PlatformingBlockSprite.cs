using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class PlatformingBlockSprite : ISprite
    {
        private Texture2D platformingBlockSpriteSheet;
        public PlatformingBlockSprite()
        {
            platformingBlockSpriteSheet = BlockSpriteTextureStorage.CreatePlatformingBlockSprite();
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
