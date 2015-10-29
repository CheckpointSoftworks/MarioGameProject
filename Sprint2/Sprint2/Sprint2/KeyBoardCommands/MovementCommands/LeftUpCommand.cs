using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class LeftUpCommand : ICommand
    {
        private Game1 Game;

        public LeftUpCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            ((Mario)Game.mario).rigidbody.Jump();
            ((Mario)Game.mario).rigidbody.MoveLeft();
        }
    }
}
