using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class QuestionStarCommand:ICommand
    {
        private IBlock block;
        private Game1 game;
        public QuestionStarCommand(IBlock block, Game1 game)
        {
            this.block = block;
            this.game = game;
        }
        public void Execute()
        {
            ((QuestionStarBlock)block).bounceBlock();
            block.Update();
            IItemObjects superStar = ((QuestionStarBlock)block).spawnStar();
            game.levelStore.staticObjectsList.Add(superStar);
        }
    }
}
