using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class GroundBlock : IBlock
    {
        private ISprite groundBlockSprite;
        private BlockType type;
        private bool testForCollision;
        public GroundBlock(int locX,int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            groundBlockSprite = new GroundBlockSprite(location);
            type = BlockType.Ground;
            testForCollision = true;
        }
        public void Update()
        {
            groundBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            groundBlockSprite.Draw(spriteBatch);
        }
        public BlockType returnBlockType()
        {
            return type;
        }

        public Rectangle  returnCollisionRectange()
        {
            return groundBlockSprite.returnCollisionRectangle();
        }

        public bool checkForCollisionTestFlag()
        {
            return testForCollision;
        }
    }
}
