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
        private bool smashed;

        public BrickBlockSprite()
        {
            brickBlockSpriteSheet = BlockSpriteTextureStorage.CreateBrickBlockSprite();
            smashed = false;
        }
        public void Update()
        {
            //Cause Brick block to disapper
            smashed = !smashed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
