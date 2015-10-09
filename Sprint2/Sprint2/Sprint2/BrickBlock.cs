using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BrickBlock : IBlock
    {
        private ISprite brickBlockSprite;
        private BlockType type;
        
        public BrickBlock(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            brickBlockSprite = new BrickBlockSprite(location);
            type = BlockType.Brick;
        }
        public void Update()
        {
            brickBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            brickBlockSprite.Draw(spriteBatch);
        }

        public BlockType returnBlockType()
        {
            return type;
        }

        public Rectangle returnCollisionRectange()
        {
            return brickBlockSprite.returnCollisionRectangle();
        }
    }
}
