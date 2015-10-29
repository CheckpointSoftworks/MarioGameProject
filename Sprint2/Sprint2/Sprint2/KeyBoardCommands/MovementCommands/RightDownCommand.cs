using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class RightDownCommand : ICommand
    {
        private Game1 Game;

        public RightDownCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            ((Mario)Game.mario).State.Duck();
        }
    }
}
