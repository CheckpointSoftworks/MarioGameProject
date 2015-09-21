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
        private bool used;

        public HiddenBlockSprite()
        {
            hiddenBlockSpriteSheet = BlockSpriteTextureStorage.CreateHiddenBlockSprite();
            used = false;
        }
        public void Update()
        {
            //Change the question block to the opposite of what it currently is
            used = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
