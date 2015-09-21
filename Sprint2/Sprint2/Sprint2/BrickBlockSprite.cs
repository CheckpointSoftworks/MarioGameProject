using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BrickBlockSprite : ISprite
    {
        private Texture2D brickBlockSpriteSheet;

        public BrickBlockSprite()
        {
            brickBlockSpriteSheet = BlockSpriteTextureStorage.CreateBrickBlockSprite();
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
