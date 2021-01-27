using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class QuestionIceFlowerCommand : ICommand
    {
        private IBlock block;
        private Game1 game;

        public QuestionIceFlowerCommand(IBlock block, Game1 game)
        {
            this.block = block;
            this.game = game;
        }
        public void Execute()
        {
            ((QuestionIceFlower)block).bounceBlock();
            block.Update();
            if (((QuestionIceFlower)block).dispenseItem())
            {
                IItemObjects iceFlower = ((QuestionIceFlower)block).spawnIceFlower();
                game.levelStore.itemList.Add(iceFlower);
            }
        }
    }
}