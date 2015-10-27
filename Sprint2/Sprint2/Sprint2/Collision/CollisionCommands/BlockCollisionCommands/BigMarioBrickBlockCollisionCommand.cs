using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class BigMarioBrickBlockCollisionCommand : ICommand
    {
        private IBlock block;
        private Game1 game;

        public BigMarioBrickBlockCollisionCommand(IBlock block,Game1 game)
        {
            this.block = block;
            this.game = game;
        }

        public void Execute()
        {
            ((BrickBlock)block).smashBlock();
            ((BrickBlock)block).becomeSmashed(game.levelStore.enviromentalObjectsList);
            block.Update();
            block.removeFromTestingCollision();
        }
    }
}
