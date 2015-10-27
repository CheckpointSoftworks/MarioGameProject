using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class BigMarioBrickBlockCollisionCommand : ICommand
    {
        private IBlock block;

        public BigMarioBrickBlockCollisionCommand(IBlock block)
        {
            this.block = block;
        }

        public void Execute()
        {
            ((BrickBlock)block).smashBlock();
            block.Update();
            block.removeFromTestingCollision();
        }
    }
}
