using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class EnemyEnemyCollisionHandler
    {
        public EnemyEnemyCollisionHandler()
        {

        }
        public void handleCollision(IEnemyObject firstEnemy,IEnemyObject secondEnemy, ICollision side)
        {
            if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                handleEnemyMovement(firstEnemy, secondEnemy, side);
            }
            //flip one of the enemies
        }

        private void handleEnemyMovement(IEnemyObject firstEnemy, IEnemyObject secondEnemy, ICollision side)
        {
            //handle moving an enemy
        }
    }
}
