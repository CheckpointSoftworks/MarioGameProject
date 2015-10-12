using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class RightUpCommand : ICommand
    {
        private Game1 Game;

        public RightUpCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            ((Mario)Game.mario).FacingRight = true;
            ((Mario)Game.mario).State.JumpRun();
        }
    }
}
