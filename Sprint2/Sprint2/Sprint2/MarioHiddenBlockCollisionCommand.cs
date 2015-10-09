using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class MarioHiddenBlockCollisionCommand:ICommand
    {
        private IBlock block;
        public MarioHiddenBlockCollisionCommand(IBlock block)
        {
            this.block = block;
        }
        public void Execute()
        {
            block.Update();
        }
    }
}
