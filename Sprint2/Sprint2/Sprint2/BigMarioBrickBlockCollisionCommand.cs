using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class BigMarioBrickBlockCollisionCommand : ICommand
    {
        private IGameObject block;

        public BigMarioBrickBlockCollisionCommand(IGameObject block)
        {
            this.block = block;
        }

        public void Execute()
        {
            block.Update();
        }
    }
}
