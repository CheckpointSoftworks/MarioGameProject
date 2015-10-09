using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class MarioOneUpMushroomCollisionCommand:ICommand
    {
        private IItemObjects oneUpMushroom;
        public MarioOneUpMushroomCollisionCommand(IItemObjects oneUpMushroom)
        {
            this.oneUpMushroom = oneUpMushroom;
        }
        public void Execute()
        {

        }
    }
}
