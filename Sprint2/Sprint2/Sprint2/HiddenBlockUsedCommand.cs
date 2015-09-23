using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class HiddenBlockUsedCommand : ICommand
    {
            private Game1 Game;

            public HiddenBlockUsedCommand(Game1 game)
            {
                Game = game;
            }

            public void Execute()
            {
                Game.hiddenBlock.Update();
            }
    }
}
