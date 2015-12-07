using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class NoPauseCommand:ICommand
    {
        private Game1 game;
        public NoPauseCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.setCanPause(true);
        }
    }
}
