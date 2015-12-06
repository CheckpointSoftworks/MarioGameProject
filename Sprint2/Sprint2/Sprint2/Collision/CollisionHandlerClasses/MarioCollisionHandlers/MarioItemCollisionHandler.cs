using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public static class MarioItemCollisionHandler
    {
        public static void handleCollision(Mario mario, IItemObjects item, ICollision side)
        {
            ICommand command;
            if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                handleMarioMovement(mario, item, side);
                command = chooseCorrectCommand(item,mario);
                command.Execute();
                mario.ScoreEvent(item.ScoreData());
                handleAchievements(item);                
            }
        }

        private static void handleAchievements(IItemObjects item)
        {
            if (item.returnItemType().Equals(ItemType.FireFlower))
            {
                AchievementEventTracker.fireFlowerAcievement();
            }
            else if (item.returnItemType().Equals(ItemType.OneUpMushroom))
            {
                AchievementEventTracker.oneUpAcievement();
            }
            else if (item.returnItemType().Equals(ItemType.Star))
            {
                AchievementEventTracker.starAcievement();
            }
            else if (item.returnItemType().Equals(ItemType.SuperMushroom))
            {
                AchievementEventTracker.superMushAcievement();
            }
        }
        private static ICommand chooseCorrectCommand(IItemObjects item,IPlayer mario)
        {
            ICommand command;
            if (item.returnItemType().Equals(ItemType.Coin))
            {
                command = new MarioCoinCollisionCommand(mario, item);
            }
            else if (item.returnItemType().Equals(ItemType.FireFlower))
            {
                command = new MarioFireFlowerCollisionCommand(mario, item);
                if (!((Mario)mario).Fire)
                {
                    StatePuaseAlterationCall.Execute();
                }
            }else if(item.returnItemType().Equals(ItemType.OneUpMushroom))
            {                
                command = new MarioOneUpMushroomCollisionCommand(mario, item);
            }else if(item.returnItemType().Equals(ItemType.Star))
            {
                command = new MarioStarCollisionCommand(mario, item);
            }
            else
            {
                command = new MarioSuperMushroomCollisionCommand(mario, item);
                if (((Mario)mario).Small)
                {
                    StatePuaseAlterationCall.Execute();
                }
            }
            return command;
        }
        private static void handleMarioMovement(Mario mario, IItemObjects item, ICollision side)
        {
            Rectangle itemRectangle = item.returnCollisionRectangle();
            Rectangle marioRectangle = mario.returnCollisionRectangle();
            Rectangle intersectionRectangle = Rectangle.Intersect(marioRectangle, itemRectangle);
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
    }
}
