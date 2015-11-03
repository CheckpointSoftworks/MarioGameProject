using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class NoJumpCommand : ICommand
    {
        private Game1 Game;

        public NoJumpCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            ((Mario)Game.mario).rigidbody.NoJump();
        }
    }
}
