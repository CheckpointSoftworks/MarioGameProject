using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class MarioSuperMushroomCollisionCommand:ICommand
    {
        private IPlayer mario;
        private IItemObjects superMushroom;
        public MarioSuperMushroomCollisionCommand(IPlayer mario,IItemObjects superMushroom)
        {
            this.mario = mario;
            this.superMushroom = superMushroom; 
        }
        public void Execute()
        {

        }
    }
}
