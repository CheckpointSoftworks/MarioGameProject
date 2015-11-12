using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class NoFireCommand : ICommand
    {
        private Game1 Game;

        public NoFireCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            ((Mario)Game.mario).CanFire = true;
        }
    }
}
