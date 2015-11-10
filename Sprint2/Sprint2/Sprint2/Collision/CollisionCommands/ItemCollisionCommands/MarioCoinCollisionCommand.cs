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
        private IPlayer player;
        
        public MarioCoinCollisionCommand(IPlayer mario, IItemObjects coin)
        {
            this.coin = coin;
            player = mario;
        }
        public void Execute()
        {
            coin.setCollisionRectangle(new Rectangle(0, 0, 0, 0));
            ((Mario)player).AddCoin();
        }
    }
}
