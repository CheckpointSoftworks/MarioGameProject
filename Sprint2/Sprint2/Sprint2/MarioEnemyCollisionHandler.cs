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
            if (!(side.returnCollisionSide().Equals(ICollision.CollisionSide.None)))
            {
                //Handle moving mario and the enemy to no longer collide
            }

            if (side.returnCollisionSide().Equals(ICollision.CollisionSide.Top))
            {
                //Mario takes no damage
                //Enemy is damaged/killed
                command = new MarioHitsEnemyCollision(enemy);
            }
            else if (!(side.returnCollisionSide().Equals(ICollision.CollisionSide.None)))
            {
                //Enemy takes no damage
                //Mario takes damage
                command = new EnemyHitsMarioCollision(mario);
            }

        }

        private void HandleMovement(Mario mario, IEnemyObject enemy)
        {
            Rectangle enemyRectangle= enemy.returnCollisionRectange();
            Rectangle marioRectangle;
        }
    }
}
