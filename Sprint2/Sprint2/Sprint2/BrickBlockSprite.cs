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
        private Vector2 location;

        public BrickBlockSprite()
        {
            brickBlockSpriteSheet = BlockSpriteTextureStorage.CreateBrickBlockSprite();
            smashed = false;
            location = new Vector2(500, 400);
        }
        public void Update()
        {
            //Cause Brick block to disapper
            smashed = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int spriteSheetSpriteSize = 16;
            Rectangle sourceRectangle = new Rectangle(0, 0, 0, 0);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);

            if (!smashed)
            {
                sourceRectangle = new Rectangle((spriteSheetSpriteSize), 0, (spriteSheetSpriteSize), (spriteSheetSpriteSize));
            }
            else
            {
                sourceRectangle = new Rectangle((spriteSheetSpriteSize * 6), 0, (spriteSheetSpriteSize), spriteSheetSpriteSize);
            }
            spriteBatch.Begin();
            spriteBatch.Draw(brickBlockSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
