﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class MarioQuestionCoinBlockCollisionCommand:ICommand
    {
        private IBlock block;
        private Game1 game;
        public MarioQuestionCoinBlockCollisionCommand(IBlock block,Game1 game)
        {
            this.block = block;
            this.game = game;
        }
        public void Execute()
        {
            ((QuestionCoinBlock)block).bounceBlock();
            block.Update();
            IItemObjects coin=((QuestionCoinBlock)block).spawnCoin();
            game.levelStore.staticObjectsList.Add(coin);
        }
    }
}