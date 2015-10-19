using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class HiddenBlock : IBlock
    {
        private ISprite hiddenBlockSprite;
        private BlockType type;
        private bool testForCollision;
        private bool isHit;
        public HiddenBlock(int locX,int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            hiddenBlockSprite = new HiddenBlockSprite(location);
            type = BlockType.Hidden;
            testForCollision = true;
            isHit = false;
        }
        public void Update()
        {
            hiddenBlockSprite.Update();
            isHit = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            hiddenBlockSprite.Draw(spriteBatch);
        }
        public BlockType returnBlockType()
        {
            return type;
        }
        public Rectangle returnCollisionRectange()
        {
            return hiddenBlockSprite.returnCollisionRectangle();
        }
        public bool checkForCollisionTestFlag()
        {
            return testForCollision;
        }
        public bool checkForHit()
        {
            return isHit;
        }
    }
}
