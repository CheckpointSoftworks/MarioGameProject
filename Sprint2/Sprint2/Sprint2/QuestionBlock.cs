using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class QuestionBlock :IGameObject
    {
        private QuestionBlockSprite questionBlockSprite;

        public QuestionBlock()
        {
            questionBlockSprite = new QuestionBlockSprite();
        }

        public void Update()
        {
            questionBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            questionBlockSprite.Draw(spriteBatch);
        }
    }
}
