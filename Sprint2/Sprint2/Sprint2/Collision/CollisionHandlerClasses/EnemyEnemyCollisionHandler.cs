using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
        }

        private void handleEnemyMovement(IEnemyObject firstEnemy, IEnemyObject secondEnemy, ICollision side)
        {
            Rectangle firstEnemyRectangle = firstEnemy.returnCollisionRectangle();
            Rectangle secondEnemyRectangle = secondEnemy.returnCollisionRectangle();
            Rectangle intersectionRectangle = Rectangle.Intersect(secondEnemyRectangle, firstEnemyRectangle);
            Vector2 enemyLocation = firstEnemy.returnLocation();
            int locationDiffToChange = 0;
            Console.WriteLine("Enemy-" + firstEnemy + "-enemy -" + secondEnemy + " collision: " + side);
            if (side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newEnemyX = (int)enemyLocation.X - locationDiffToChange;
                firstEnemy.updateLocation(new Vector2((newEnemyX), enemyLocation.Y));
                firstEnemy.RightCollision();
                ICommand flipEnemyDir = new EnemyChangeDirectionCommand(firstEnemy);
                flipEnemyDir.Execute();
                //secondEnemy.RightCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newEnemyX = (int)enemyLocation.X + locationDiffToChange;
                firstEnemy.updateLocation(new Vector2((newEnemyX), enemyLocation.Y));
                firstEnemy.LeftCollision();
                ICommand flipEnemyDir = new EnemyChangeDirectionCommand(firstEnemy);
                flipEnemyDir.Execute();
                //secondEnemy.LeftCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newEnemyY = (int)enemyLocation.Y - locationDiffToChange;
                firstEnemy.updateLocation(new Vector2(enemyLocation.X, newEnemyY));
                firstEnemy.TopCollision();
              //  secondEnemy.TopCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newEnemyY = (int)enemyLocation.Y + locationDiffToChange;
                firstEnemy.updateLocation(new Vector2(enemyLocation.X, newEnemyY));
                firstEnemy.BottomCollision();
               // secondEnemy.BottomCollision();
            }
        }
    }
}
