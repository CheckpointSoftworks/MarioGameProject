using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class QuestionBlockSprite : ISprite
    {
        private Texture2D questionBlockSpriteSheet;
        private bool used;
        private Vector2 location;

        public QuestionBlockSprite()
        {
            questionBlockSpriteSheet = BlockSpriteTextureStorage.CreateQuestionBlockSpriteSheet();
            used = false;
            location = new Vector2(400, 200);
        }

        public void Update()
        {
            //Change the state of the Question block, do not address the bouncing of it in this Sprint
            used = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int spriteSheetSpriteSize = 16;
            Rectangle sourceRectangle = new Rectangle(0, 0, 0, 0);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);

            if (!used)
            {
                sourceRectangle = new Rectangle((spriteSheetSpriteSize*4), 0, (spriteSheetSpriteSize), (spriteSheetSpriteSize));
            }
            else
            {
                sourceRectangle = new Rectangle((spriteSheetSpriteSize * 5), 0, (spriteSheetSpriteSize), spriteSheetSpriteSize);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(questionBlockSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
