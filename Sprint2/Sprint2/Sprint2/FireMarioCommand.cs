using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class FireMarioCommand : ICommand
    {
            private Game1 Game;

            public FireMarioCommand(Game1 game)
            {
                Game = game;
            }

            public void Execute()
            {
                Game.mario.fire = true;
            }
    }
}
