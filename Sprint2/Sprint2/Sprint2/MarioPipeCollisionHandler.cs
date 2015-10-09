using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
   public class MarioPipeCollisionHandler{
        public void HandleCollision(Mario mario, IBlock block, ICollision side)
        {

            if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                HandleMovement(mario, block, side);
            }

        }
        private void HandleMovement(Mario mario, IBlock enemy, ICollision side)
        {
            Rectangle enemyRectangle = enemy.returnCollisionRectange();
            Rectangle marioRectangle = mario.returnCollisionRectangle();
            Rectangle intersectionRectangle = Rectangle.Intersect(marioRectangle, enemyRectangle);
            int locationDiffToChange = 0;

            if (side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                locationDiffToChange = intersectionRectangle.Width;
                mario.location.X = mario.location.X - locationDiffToChange;
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                locationDiffToChange = intersectionRectangle.Width;
                mario.location.X = mario.location.X + locationDiffToChange;
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                locationDiffToChange = intersectionRectangle.Height;
                mario.location.Y = mario.location.Y - locationDiffToChange;
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                locationDiffToChange = intersectionRectangle.Height;
                mario.location.Y = mario.location.Y + locationDiffToChange;
            }
        }

    }
}
