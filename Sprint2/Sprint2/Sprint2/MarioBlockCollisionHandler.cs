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

            if (!(side.returnCollisionSide().Equals(ICollision.CollisionSide.None)))
            {
              //Handle Moving Mario so he no longer collides with the blocks
            }

            //Only side that matters is from below and None
            if (side.returnCollisionSide().Equals(ICollision.CollisionSide.Bottom))
            {
                chooseCollisionCommand(mario, block);
            }
        }

        private void chooseCollisionCommand(Mario mario, IBlock block)
        {
            IBlock.BlockType type = block.returnBlockType();
            ICommand command;
            if (type.Equals(IBlock.BlockType.Question))
            {
                command = new MarioQuestionBlockCollisionCommand(block);
                command.Execute();
            }
            else if (type.Equals(IBlock.BlockType.Hidden))
            {
                command = new MarioHiddenBlockCollisionCommand(block);
                command.Execute();
            }
            else if (type.Equals(IBlock.BlockType.Brick)&&(!mario.Small))
            {
                command = new BigMarioBrickBlockCollisionCommand(block);
                command.Execute();
            }

        }

    }
}
