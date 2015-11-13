using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class MarioOneUpMushroomCollisionCommand:ICommand
    {
        private IItemObjects oneUpMushroom;
        private IPlayer player;
        public MarioOneUpMushroomCollisionCommand(IPlayer mario, IItemObjects oneUpMushroom)
        {
            SoundEffectFactory.OneUp();
            player = mario;
            this.oneUpMushroom = oneUpMushroom;
        }
        public void Execute()
        {
            oneUpMushroom.setCollisionRectangle(new Rectangle(UtilityClass.zero, UtilityClass.zero, UtilityClass.zero, UtilityClass.zero));
            ((Mario)player).OneUp();
        }
    }
}
