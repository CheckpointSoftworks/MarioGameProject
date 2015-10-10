using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
            fireFlower.setCollisionRectangle(new Microsoft.Xna.Framework.Rectangle(0, 0, 0, 0));
            ((Mario)mario).Fire = true;
            ((Mario)mario).Small = false;
        }
    }
}
