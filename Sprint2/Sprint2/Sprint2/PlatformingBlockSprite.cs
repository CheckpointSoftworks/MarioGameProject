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
        private Vector2 location;

        public PlatformingBlockSprite()
        {
            platformingBlockSpriteSheet = BlockSpriteTextureStorage.CreatePlatformingBlockSpriteSheet();
            location = new Vector2(200, 200);
        }

        public void Update()
        {
            //No update logic needed, object is static and non-anitmated
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int spriteSheetSpriteSize = 16;
            Rectangle sourceRectangle = new Rectangle((spriteSheetSpriteSize * 7), 0, spriteSheetSpriteSize, spriteSheetSpriteSize);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);

            spriteBatch.Begin();
            spriteBatch.Draw(platformingBlockSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
            
        }
    }
}
