using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class LeftCommand: ICommand
    {
            private Game1 Game;

            public LeftCommand(Game1 game)
            {
                Game = game;
            }

            public void Execute()
            {
                Game.mario.facingRight = false;
            }
    }
}
