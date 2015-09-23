using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class QuestionBlockUsedCommand
    {
            private Game1 Game;

            public QuestionBlockUsedCommand(Game1 game)
            {
                Game = game;
            }

            public void Execute()
            {
                Game.questionblock.update();
            }
    }
}
