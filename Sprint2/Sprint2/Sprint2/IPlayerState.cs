using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public interface IPlayerState
    {
        void Still();
        void Running();
        void ChangeDirection();
        void Jump();
        void ShootFireball();
        void Duck();
        void Dying();
        void Draw(SpriteBatch spriteBatch);

        Rectangle returnStateCollisionRectangle();

    }
}
