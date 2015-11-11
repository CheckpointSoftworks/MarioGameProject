using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public static class MarioEnemyCollisionHandler
    {
        public static void handleCollision(Mario mario, IEnemyObject enemy, ICollision side)
        {
            ICommand command;
            if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                handleMarioMovement(mario, enemy, side);
            }

            if (side.returnCollisionSide().Equals(CollisionSide.Top)&&enemy.canHurtMario())
            {
                command = new MarioHitsEnemyCollision(enemy, mario);
                command.Execute();
            }
            else if (!(side.returnCollisionSide().Equals(CollisionSide.None))&&enemy.canHurtMario())
            {
                command = new EnemyHitsMarioCollision(mario,enemy);
                command.Execute();
            }
            if (enemy.canHurtOtherEnemies()&&!(side.returnCollisionSide().Equals(CollisionSide.None))&&!enemy.canHurtMario())
            {
                handleMarioMovement(mario, enemy, side);
                handleEnemtMovement(enemy,side);
            }
        }

        private static void handleMarioMovement(Mario mario, IEnemyObject enemy,ICollision side)
        {
            Rectangle enemyRectangle= enemy.returnCollisionRectangle();
            Rectangle marioRectangle = mario.returnCollisionRectangle();
            Rectangle intersectionRectangle = Rectangle.Intersect(marioRectangle, enemyRectangle);
            int locationDiffToChange = UtilityClass.zero;

            if (side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newMarioX = (int)mario.Location.X - locationDiffToChange;
                mario.Location = new Vector2(newMarioX, mario.Location.Y);
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newMarioX = (int)mario.Location.X + locationDiffToChange;
                mario.Location = new Vector2(newMarioX, mario.Location.Y);
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newMarioY = (int)mario.Location.Y - locationDiffToChange;
                mario.Location = new Vector2(mario.Location.X, newMarioY);
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newMarioY = (int)mario.Location.Y + locationDiffToChange;
                mario.Location = new Vector2(mario.Location.X, newMarioY);
            }
        }

        private static void handleEnemtMovement(IEnemyObject enemy,ICollision side)
        {
            if (side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                ((Koopa)enemy).shellLeftHit();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                ((Koopa)enemy).shellRightHit();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                ((Koopa)enemy).shellLeftHit();
            }
        }
    }
}
