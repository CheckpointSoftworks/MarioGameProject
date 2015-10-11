using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
   public class MarioPipeCollisionHandler{
        public MarioPipeCollisionHandler()
        {

        }

        public void HandleCollision(Mario mario, IEnviromental enviromental, ICollision side)
        {

            if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                HandleMovement(mario, enviromental, side);
            }

        }
        private void HandleMovement(Mario mario, IEnviromental enviromental, ICollision side)
        {
            Rectangle enviromentalRectangle = enviromental.returnCollisionRectangle();
            Rectangle marioRectangle = mario.returnCollisionRectangle();
            Rectangle intersectionRectangle = Rectangle.Intersect(marioRectangle, enviromentalRectangle);
            int locationDiffToChange = 0;

            if (side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newMarioX = (int)mario.Location.X-locationDiffToChange;
                mario.Location = new Vector2(newMarioX,mario.Location.Y);
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
                mario.Location = new Vector2(mario.Location.Y, newMarioY);
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newMarioY = (int)mario.Location.Y + locationDiffToChange;
                mario.Location = new Vector2(mario.Location.Y,newMarioY);
            }
        }

    }
}
