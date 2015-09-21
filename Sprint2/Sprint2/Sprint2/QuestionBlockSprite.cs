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
        public QuestionBlockSprite()
        {
            questionBlockSpriteSheet = BlockSpriteTextureStorage.CreateQuestionBlockSprite();
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
