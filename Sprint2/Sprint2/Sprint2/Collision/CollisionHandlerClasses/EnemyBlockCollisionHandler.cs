using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class EnemyBlockCollisionHandler
    {
        public EnemyBlockCollisionHandler()
        {

        }
        public void handleCollision(IEnemyObject enemy, IBlock block, ICollision side)
        {
            if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                handleEnemyMovement(enemy, block, side);
            }
        }

        private void handleEnemyMovement(IEnemyObject enemy,IBlock block,ICollision side)
        {
            Rectangle blockRectangle = block.returnCollisionRectange();
            Rectangle enemyRectangle = enemy.returnCollisionRectangle();
            Rectangle intersectionRectangle = Rectangle.Intersect(enemyRectangle, blockRectangle);
            Vector2 enemyLocation = enemy.returnLocation();
            int locationDiffToChange = 0;

            if (side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newEnemyX = (int)enemyLocation.X - locationDiffToChange;
                enemy.updateLocation(new Vector2((newEnemyX), enemyLocation.Y));
                enemy.RightCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newEnemyX = (int)enemyLocation.X + locationDiffToChange;
                enemy.updateLocation(new Vector2((newEnemyX), enemyLocation.Y));
                enemy.LeftCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newEnemyY = (int)enemyLocation.Y - locationDiffToChange;
                enemy.updateLocation(new Vector2(enemyLocation.X, newEnemyY));
                enemy.BottomCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newEnemyY = (int)enemyLocation.Y + locationDiffToChange;
                enemy.updateLocation(new Vector2(enemyLocation.X, newEnemyY));
                enemy.TopCollision();
            }
        }
    }
}
