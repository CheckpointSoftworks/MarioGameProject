using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class MarioItemCollisionHandler
    {
        public MarioItemCollisionHandler()
        {

        }
        public void HandleCollision(Mario mario, IItemObjects item, ICollision side)
        {
            ICommand command;
            if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                HandleMovement(mario, item, side);
                command = chooseCorrectCommand(item,mario);
                command.Execute();
            }


        }
        private ICommand chooseCorrectCommand(IItemObjects item,IPlayer mario)
        {
            ICommand command;
            if (item.returnItemType().Equals(ItemType.Coin))
            {
                command = new MarioCoinCollisionCommand(item);
            }
            else if (item.returnItemType().Equals(ItemType.FireFlower))
            {
                command = new MarioFireFlowerCollisionCommand(mario, item);
            }else if(item.returnItemType().Equals(ItemType.OneUpMushroom))
            {
                command = new MarioOneUpMushroomCollisionCommand(item);
            }else if(item.returnItemType().Equals(ItemType.Star))
            {
                command = new MarioStarCollisionCommand(mario, item);
            }
            else
            {
                command = new MarioSuperMushroomCollisionCommand(mario, item);
            }
            return command;
        }
        private void HandleMovement(Mario mario, IItemObjects item, ICollision side)
        {
            Rectangle itemRectangle = item.returnCollisionRectangle();
            Rectangle marioRectangle = mario.returnCollisionRectangle();
            Rectangle intersectionRectangle = Rectangle.Intersect(marioRectangle, itemRectangle);
            int locationDiffToChange = 0;

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
                mario.Location = new Vector2(mario.Location.Y, newMarioY);
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newMarioY = (int)mario.Location.Y + locationDiffToChange;
                mario.Location = new Vector2(mario.Location.Y, newMarioY);
            }
        }
    }
}
