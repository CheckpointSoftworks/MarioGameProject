using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class ResetCommand:ICommand
    {
            private Game1 Game;

            public ResetCommand(Game1 game)
            {
                Game = game;
            }

            public void Execute()
            {
                
            }
    }
}
