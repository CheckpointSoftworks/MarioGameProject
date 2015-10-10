﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
            superMushroom.setCollisionRectangle(new Rectangle(0, 0, 0, 0));
            ((Mario)mario).Small = false;
            ((Mario)mario).Fire = false;
        }
    }
}
