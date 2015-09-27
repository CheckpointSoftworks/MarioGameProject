using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class PipeSprite : ISprite
    {
        private Texture2D pipeSpriteSheet;
        private Vector2 location;
        public PipeSprite()
        {
            pipeSpriteSheet = MiscGameObjectTextureStorage.CreatePipeSpriteSheet();
            location = new Vector2(700, 200);
        }
        public void Update()
        {
            //No Update Logic Needed
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int spriteSheetSpriteSize = 31;
            Rectangle sourceRectangle = new Rectangle(spriteSheetSpriteSize * 0, 0, spriteSheetSpriteSize, spriteSheetSpriteSize);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);

            spriteBatch.Begin();
            spriteBatch.Draw(pipeSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
