using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class QuestionSuperMushroomCommand:ICommand
    {
        private IBlock block;
        private Game1 game;
        public QuestionSuperMushroomCommand(IBlock block, Game1 game)
        {
            this.block = block;
            this.game = game;
        }
        public void Execute()
        {
            ((QuestionSuperMushroomFireFlower)block).bounceBlock();
            block.Update();
            IItemObjects superMushroom = ((QuestionSuperMushroomFireFlower)block).spawnSuperMushroom();
            game.levelStore.staticObjectsList.Add(superMushroom);
        }
    }
}
