using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class SmallMarioCommand : ICommand
    {
            private Game1 Game;

            public SmallMarioCommand(Game1 game)
            {
                Game = game;
            }

            public void Execute()
            {
               ((Mario)Game.mario).Small = true;
               ((Mario)Game.mario).Fire = false;
            }
    }
}
