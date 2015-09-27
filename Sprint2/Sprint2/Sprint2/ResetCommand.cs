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
                Game.mario = new Mario();

                Game.dynamicObjectsList.Remove(Game.hiddenBlock);
                Game.dynamicObjectsList.Remove(Game.brickBlock);
                Game.dynamicObjectsList.Remove(Game.questionBlock);

                Game.hiddenBlock = new HiddenBlock();
                Game.questionBlock = new QuestionBlock();
                Game.brickBlock = new BrickBlock();

                Game.dynamicObjectsList.Add(Game.hiddenBlock);
                Game.dynamicObjectsList.Add(Game.questionBlock);
                Game.dynamicObjectsList.Add(Game.brickBlock);
            }
    }
}
