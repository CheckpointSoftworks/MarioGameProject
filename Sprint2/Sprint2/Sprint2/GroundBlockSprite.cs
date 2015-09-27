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
        private Vector2 location;

        public GroundBlockSprite()
        {
            groundBlockSpriteSheet = BlockSpriteTextureStorage.CreateGroundBlockSpriteSheet();
            location = new Vector2(600, 200);
        }

        public void Update()
        {
            //No update needed for ground blocks
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int spriteSheetSpriteSize = 16;
            Rectangle sourceRectangle = new Rectangle(spriteSheetSpriteSize*0, 0, spriteSheetSpriteSize, spriteSheetSpriteSize);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);
            
            spriteBatch.Begin();
            spriteBatch.Draw(groundBlockSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
