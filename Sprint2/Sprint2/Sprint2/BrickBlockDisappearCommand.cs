using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class BrickBlockDisappearCommand
    {
            private Game1 Game;

            public BrickBlockDisappearCommand(Game1 game)
            {
                Game = game;
            }

            public void Execute()
            {
                Game.brickblock.update();
            }
    }
}
