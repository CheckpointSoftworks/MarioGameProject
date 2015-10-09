using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class QuestionBlock :IBlock
    {
        private ISprite questionBlockSprite;
        private BlockType type;

        public QuestionBlock(int locX,int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            questionBlockSprite = new QuestionBlockSprite(location);
            type = BlockType.Question;
        }
        public void Update()
        {
            questionBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            questionBlockSprite.Draw(spriteBatch);
        }
        public BlockType returnBlockType()
        {
            return type;
        }
        public Rectangle returnCollisionRectange()
        {
            return questionBlockSprite.returnCollisionRectangle();
        }
    }
}
