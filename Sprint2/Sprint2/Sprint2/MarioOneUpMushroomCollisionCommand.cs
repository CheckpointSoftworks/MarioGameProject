﻿using System;
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
        public MarioOneUpMushroomCollisionCommand(IItemObjects oneUpMushroom)
        {
            this.oneUpMushroom = oneUpMushroom;
        }
        public void Execute()
        {
            oneUpMushroom.setCollisionRectangle(new Rectangle(0, 0, 0, 0));
        }
    }
}