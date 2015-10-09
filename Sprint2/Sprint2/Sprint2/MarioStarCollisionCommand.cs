using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class MarioStarCollisionCommand:ICommand
    {
        private IPlayer mario;
        private IItemObjects star;
        public MarioStarCollisionCommand(IPlayer mario,IItemObjects star)
        {
            this.mario = mario;
            this.star = star;
        }
        public void Execute()
        {

        }
    }
}
