using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class MarioFireFlowerCollisionCommand:ICommand
    {
        private IPlayer mario;
        private IItemObjects fireFlower;
        public MarioFireFlowerCollisionCommand(IPlayer mario, IItemObjects fireFlower)
        {
            this.mario = mario;
            this.fireFlower = fireFlower;
        }
        public void Execute()
        {

        }
    }
}
