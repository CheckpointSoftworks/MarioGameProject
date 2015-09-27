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
        private Vector2 location;

        public HiddenBlockSprite()
        {
            hiddenBlockSpriteSheet = BlockSpriteTextureStorage.CreateHiddenBlockSpriteSheet();
            used = false;
            location = new Vector2(300, 200);
        }
        public void Update()
        {
            //Change the question block to the opposite of what it currently is
            used = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int spriteSheetSpriteSize = 16;
            Rectangle sourceRectangle = new Rectangle(0, 0, 0, 0);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);

            if (!used)
            {
                sourceRectangle = new Rectangle((spriteSheetSpriteSize * 6), 0, (spriteSheetSpriteSize), (spriteSheetSpriteSize));
            }
            else
            {
                sourceRectangle = new Rectangle((spriteSheetSpriteSize * 3), 0, (spriteSheetSpriteSize), spriteSheetSpriteSize);
            }
            spriteBatch.Begin();
            spriteBatch.Draw(hiddenBlockSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
