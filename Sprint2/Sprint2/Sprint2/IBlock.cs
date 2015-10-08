using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public interface IBlock:IGameObject
    {
        public enum BlockType { Brick, Hidden, Ground, Platforming, Question };

        void Update();

        void Draw(SpriteBatch spriteBatch);

        BlockType returnBlockType();

        Rectangle returnCollisionRectange();
    }
}
