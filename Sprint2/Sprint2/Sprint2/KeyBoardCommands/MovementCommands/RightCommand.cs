using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class RightCommand: ICommand
    {
            private Game1 Game;

            public RightCommand(Game1 game)
            {
                Game = game;
            }

            public void Execute()
            {
                ((Mario)Game.mario).FacingRight = true;
                ((Mario)Game.mario).State.Running();
            }
    }
}
