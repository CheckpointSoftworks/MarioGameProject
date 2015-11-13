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
            SoundEffectFactory.Coin();
            coin.setCollisionRectangle(new Rectangle(UtilityClass.zero, UtilityClass.zero, UtilityClass.zero, UtilityClass.zero));
            ((Mario)player).AddCoin();
        }
    }
}
