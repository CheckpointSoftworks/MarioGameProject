using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class BigMarioBrickBlockCollisionCommand : ICommand
    {
        private IPlayer mario;
        private IBlock block;
        private Game1 game;

        public BigMarioBrickBlockCollisionCommand(IPlayer mario, IBlock block,Game1 game)
        {
            this.block = block;
            this.game = game;
            this.mario = mario;
        }

        public void Execute()
        {
            ((BrickBlock)block).smashBlock();
            ((BrickBlock)block).becomeSmashed(game.levelStore.enviromentalObjectsList);
            block.Update();
            block.removeFromTestingCollision();
            ((Mario)mario).ScoreEvent(((BrickBlock)block).ScoreData());
            ((Mario)mario).stats.BrokeBrickBlock();
        }
    }
}
