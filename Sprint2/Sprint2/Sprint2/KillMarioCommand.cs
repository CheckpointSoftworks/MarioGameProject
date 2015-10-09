using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class KillMarioCommand : ICommand
    {
        private Game1 Game;

        public KillMarioCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            ((Mario)Game.mario).State.Dying();
        }
    }
}
