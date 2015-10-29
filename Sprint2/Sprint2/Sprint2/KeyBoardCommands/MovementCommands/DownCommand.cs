using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class DownCommand: ICommand
    {
            private Game1 Game;

            public DownCommand(Game1 game)
            {
                Game = game;
            }

            public void Execute()
            {
                Console.WriteLine("Mario duck");
                ((Mario)Game.mario).State.Duck();    
            }
    }
}
