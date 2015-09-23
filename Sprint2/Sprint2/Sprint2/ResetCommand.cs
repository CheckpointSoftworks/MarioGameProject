using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class ResetCommand:ICommand
    {
            private Game1 Game;

            public ResetCommand(Game1 game)
            {
                Game = game;
            }

            public void Execute()
            {
                Game.mario.small = true;
                Game.mario.facingRight = false;
                Game.mario.state.Still();

                Game.blockObjectList.Remove(Game.hiddenBlock);
                Game.blockObjectList.Remove(Game.brickBlock);
                Game.blockObjectList.Remove(Game.questionBlock);

                Game.hiddenBlock = new HiddenBlock();
                Game.questionBlock = new QuestionBlock();
                Game.brickBlock = new BrickBlock();

                Game.blockObjectList.Add(Game.hiddenBlock);
                Game.blockObjectList.Add(Game.brickBlock);
                Game.blockObjectList.Add(Game.questionBlock);
            }
    }
}
