using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public static class EnemyProjectileCollisionHandler
    {
        public static void handleCollision(IEnemyObject enemy, IProjectile projectile, ICollision side)
        {
            if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                handleMovement(enemy, projectile, side);
            }

            if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                ICommand command = new ProjectileHitsEnemyCollision(enemy, projectile);
                command.Execute();
            }
        }

        private static void handleMovement(IEnemyObject enemy, IProjectile projectile, ICollision side)
        {
            Rectangle projectileRectangle = projectile.returnCollisionRectangle();
            Rectangle enemyRectangle = enemy.returnCollisionRectangle();
            Rectangle intersectionRectangle = Rectangle.Intersect(enemyRectangle, projectileRectangle);
            Vector2 enemyLocation = enemy.returnLocation();
            int locationDiffToChange = UtilityClass.zero;

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
