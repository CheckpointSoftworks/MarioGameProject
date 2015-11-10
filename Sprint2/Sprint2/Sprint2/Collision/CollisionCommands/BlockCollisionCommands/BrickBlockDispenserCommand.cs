using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class BrickBlockDispenserCommand:ICommand
    {
        private IBlock block;
        private Game1 game;
        private IPlayer mario;
        public BrickBlockDispenserCommand(IPlayer mario, IBlock block, Game1 game)
        {
            this.mario = mario;
            this.block = block;
            this.game = game;
        }
        public void Execute()
        {
            ((BrickBlockCoinDispenser)block).bounceBlock();
            if (((BrickBlockCoinDispenser)block).coinCounting())
            {
                IItemObjects coin = ((BrickBlockCoinDispenser)block).dispenseCoin();
                ((Mario)mario).AddCoin();
                game.levelStore.itemList.Add(coin);
            }
        }
    }
}
