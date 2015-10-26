using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class EnemyEnviromentalCollisionHandler
    {
        public EnemyEnviromentalCollisionHandler()
        {

        }
        public void handleCollision(IEnemyObject enemy, IEnviromental enviromental,ICollision side)
        {
            if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                handleEnemyMovement(enemy, enviromental,side);
            }
        }

        private void handleEnemyMovement(IEnemyObject enemy,IEnviromental enviromental,ICollision side)
        {
            Rectangle enviromentalRectangle = enviromental.returnCollisionRectangle();
            Rectangle enemyRectangle = enemy.returnCollisionRectangle();
            Rectangle intersectionRectangle = Rectangle.Intersect(enemyRectangle, enviromentalRectangle);
            Vector2 enemyLocation = enemy.returnLocation();
            int locationDiffToChange = 0;

            if (side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newEnemyX = (int)enemyLocation.X - locationDiffToChange;
                enemy.updateLocation(new Vector2((newEnemyX), enemyLocation.Y));
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newEnemyX = (int)enemyLocation.X + locationDiffToChange;
                enemy.updateLocation(new Vector2((newEnemyX), enemyLocation.Y));
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newEnemyY = (int)enemyLocation.Y - locationDiffToChange;
                enemy.updateLocation(new Vector2(enemyLocation.X, newEnemyY));
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newEnemyY = (int)enemyLocation.Y + locationDiffToChange;
                enemy.updateLocation(new Vector2(enemyLocation.X, newEnemyY));
            }
        }
    }
}
