using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class MarioBlockCollisionHandler
    {
        public MarioBlockCollisionHandler()
        {

        }

        public void HandleCollision(Mario mario, IBlock block, ICollision side)
        {
            
            if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                HandleMovement(mario, block, side);
            }

            //Only side that matters is from below and None
            if (side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                chooseCollisionCommand(mario, block);
            }
        }

        private void chooseCollisionCommand(Mario mario, IBlock block)
        {
            BlockType type = block.returnBlockType();
            ICommand command;
            if (type.Equals(BlockType.Question))
            {
                command = new MarioQuestionBlockCollisionCommand(block);
                command.Execute();
            }
            else if (type.Equals(BlockType.Hidden))
            {
                command = new MarioHiddenBlockCollisionCommand(block);
                command.Execute();
            }
            else if (type.Equals(BlockType.Brick)&&(!mario.Small))
            {
                command = new BigMarioBrickBlockCollisionCommand(block);
                command.Execute();
            }

        }

        private void HandleMovement(Mario mario, IBlock block, ICollision side)
        {
            Rectangle blockRectangle = block.returnCollisionRectange();
            Rectangle marioRectangle = mario.returnCollisionRectangle();
            Rectangle intersectionRectangle = Rectangle.Intersect(marioRectangle, blockRectangle);
            int locationDiffToChange = 0;

            if (side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newMarioX = (int)mario.Location.X + locationDiffToChange;
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
                int newMarioY = (int)mario.Location.Y + locationDiffToChange;
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
