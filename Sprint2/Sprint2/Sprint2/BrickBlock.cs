using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BrickBlock : IGameObject
    {
        private ISprite brickBlockSprite;
        
        public BrickBlock(Texture2D brickBlockSpriteSheet)
        {
            brickBlockSprite = new BrickBlockSprite();
        }
        public void Update()
        {
            brickBlockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            brickBlockSprite.Draw(spriteBatch);
        }
    }
}
