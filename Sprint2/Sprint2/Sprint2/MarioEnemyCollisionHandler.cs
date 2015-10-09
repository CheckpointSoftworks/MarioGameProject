using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class MarioEnemyCollisionHandler
    {
        void HandleCollision(Mario mario, IEnemyObject enemy, ICollision side)
        {
            ICommand command;
            if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                HandleMovement(mario, enemy, side);
            }

            if (side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                //Mario takes no damage
                //Enemy is damaged/killed
                command = new MarioHitsEnemyCollision(enemy);
            }
            else if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                //Enemy takes no damage
                //Mario takes damage
                command = new EnemyHitsMarioCollision(mario);
            }

        }

        private void HandleMovement(Mario mario, IEnemyObject enemy,ICollision side)
        {
            Rectangle enemyRectangle= enemy.returnCollisionRectange();
            Rectangle marioRectangle = mario.returnCollisionRectangle();
            Rectangle intersectionRectangle = Rectangle.Intersect(marioRectangle, enemyRectangle);
            int locationDiffToChange = 0;

            if(side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                locationDiffToChange = intersectionRectangle.Width;
                mario.location.X = mario.location.X - locationDiffToChange;
            }
            else if(side.returnCollisionSide().Equals(CollisionSide.Right))
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
