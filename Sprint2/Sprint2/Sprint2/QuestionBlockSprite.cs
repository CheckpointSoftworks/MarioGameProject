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
        public QuestionBlockSprite()
        {
            questionBlockSpriteSheet = BlockSpriteTextureStorage.CreateQuestionBlockSprite();
            used = false;
        }
        public void Update()
        {
            //Change the state of the Question block, do not address the bouncing of it in this Sprint
            used = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
