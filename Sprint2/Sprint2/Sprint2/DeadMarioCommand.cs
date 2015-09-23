using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class DeadMarioCommand:ICommand
    {
        private Game1 Game;

        public DeadMarioCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.mario.state.Dying();
        }

    }
}

