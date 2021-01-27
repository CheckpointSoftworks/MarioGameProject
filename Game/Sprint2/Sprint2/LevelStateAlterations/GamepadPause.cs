using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class GamepadPause:ICommand
    {
        private Game1 game;
        public GamepadPause(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (!game.returnPause()) { 
                game.setPause(true);
            }
            else {
                game.setPause(false);
            }
        }
    }
}
