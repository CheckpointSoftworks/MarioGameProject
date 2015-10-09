using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class MarioCoinCollisionCommand:ICommand
    {
        private IItemObjects coin;
        
        public MarioCoinCollisionCommand(IItemObjects coin)
        {
            this.coin = coin;
        }
        public void Execute()
        {
            coin.setCollisionRectangle(new Rectangle(0, 0, 0, 0));
        }
    }
}
