using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class PlatformingBlock : IBlock
    {
        private PlatformingBlockSprite platformingBlockSprite;
        private BlockType type;
        public PlatformingBlock(Vector2 location)
        {
            platformingBlockSprite = new PlatformingBlockSprite(location);
            type = BlockType.Platforming;
        }
        public void Update()
        {
            platformingBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            platformingBlockSprite.Draw(spriteBatch);
        }

        public BlockType returnBlockType()
        {
            return type;
        }

        public Rectangle returnCollisionRectange()
        {
            return platformingBlockSprite.returnCollisionRectangle();
        }
    }
}
