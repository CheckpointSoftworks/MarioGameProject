using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class MarioBlockCollisionHandler
    {
        public void HandleCollision(Mario mario, IBlock block, ICollision side)
        {

            if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
              //Handle Moving Mario so he no longer collides with the blocks
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
            else if (type.Equals(BlockType.Brick)&&(!mario.small))
            {
                command = new BigMarioBrickBlockCollisionCommand(block);
                command.Execute();
            }

        }

    }
}
