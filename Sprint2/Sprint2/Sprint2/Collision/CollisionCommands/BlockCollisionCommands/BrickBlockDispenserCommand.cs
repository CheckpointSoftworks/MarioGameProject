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
        public BrickBlockDispenserCommand(IBlock block, Game1 game)
        {
            this.block = block;
            this.game = game;
        }
        public void Execute()
        {
            bool dispenseCoin=((BrickBlockCoinDispenser)block).coinCounting();
            if (dispenseCoin)
            {
                IItemObjects coin = ((BrickBlockCoinDispenser)block).dispenseCoin();
                game.levelStore.staticObjectsList.Add(coin);
            }
        }
    }
}
