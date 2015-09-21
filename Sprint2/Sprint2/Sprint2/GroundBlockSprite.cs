using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class GroundBlockSprite : ISprite
    {
        private Texture2D groundBlockSpriteSheet;
        public GroundBlockSprite()
        {
            groundBlockSpriteSheet = BlockSpriteTextureStorage.CreateGroundBlockSprite();
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
