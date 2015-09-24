using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class BigMarioCommand : ICommand
    {
            private Game1 Game;

            public BigMarioCommand(Game1 game)
            {
                Game = game;
            }

            public void Execute()
            {
                Game.mario.small = false;
                Game.mario.fire = false;
                Game.mario.isDying = false;
            }
    }
}
