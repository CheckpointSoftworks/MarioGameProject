using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class LeftDownCommand : ICommand
    {
        private Game1 Game;

        public LeftDownCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            ((Mario)Game.mario).FacingRight = false;
            ((Mario)Game.mario).State.DuckRun();
        }
    }
}
