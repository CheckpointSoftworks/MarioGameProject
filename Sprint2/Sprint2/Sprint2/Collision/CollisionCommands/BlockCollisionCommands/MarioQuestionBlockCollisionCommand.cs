using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class MarioQuestionBlockCollisionCommand:ICommand
    {
        private IBlock block;
        public MarioQuestionBlockCollisionCommand(IBlock block)
        {
            this.block = block;
        }
        public void Execute()
        {
            block.Update();
        }
    }
}
