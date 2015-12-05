using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public interface IMarioState
    {
        MarioState State();
        void Still();
        void Running();
        void ChangeDirection();
        void Jump();
        void ShootFireball();
        void ShootIceball();
        void Duck();
        void TakeDamage();
        void Dying();
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc);
        void setDrawColor(Color color);

        Rectangle returnStateCollisionRectangle();

    }
}
