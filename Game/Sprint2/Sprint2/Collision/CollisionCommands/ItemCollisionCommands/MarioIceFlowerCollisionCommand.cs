using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class MarioIceFlowerCollisionCommand : ICommand
    {
        private IPlayer mario;
        private IItemObjects iceFlower;
        public MarioIceFlowerCollisionCommand(IPlayer mario, IItemObjects iceFlower)
        {
            this.mario = mario;
            this.iceFlower = iceFlower;
        }
        public void Execute()
        {
            SoundEffectFactory.PowerUp();
            iceFlower.setCollisionRectangle(new Rectangle(UtilityClass.zero, UtilityClass.zero, UtilityClass.zero, UtilityClass.zero));
            ((Mario)mario).BecomeIce();
        }
    }
}