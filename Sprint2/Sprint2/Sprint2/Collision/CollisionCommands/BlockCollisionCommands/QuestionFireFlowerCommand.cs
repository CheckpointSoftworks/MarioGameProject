using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class QuestionFireFlowerCommand:ICommand
    {private IBlock block;
        private Game1 game;

        public QuestionFireFlowerCommand(IBlock block, Game1 game)
        {
            this.block = block;
            this.game = game;
        }
        public void Execute()
        {
            ((QuestionSuperMushroomFireFlower)block).bounceBlock();
            block.Update();
            if (((QuestionSuperMushroomFireFlower)block).dispenseItem())
            {
                IItemObjects fireFlower = ((QuestionSuperMushroomFireFlower)block).spawnFireFlower();
                game.levelStore.itemList.Add(fireFlower);
            }
        }
    }
}
