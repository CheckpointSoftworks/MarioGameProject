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
        void JumpRun();
        void ShootFireball();
        void Duck();
        void DuckRun();
        void Dying();
        void Update();
        void Draw(SpriteBatch spriteBatch);
        void setDrawColor(Color color);

        Rectangle returnStateCollisionRectangle();

    }
}
