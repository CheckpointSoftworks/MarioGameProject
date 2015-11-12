using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class StateTransistionPause:ICommand
    {
        private Game1 game;
        public StateTransistionPause(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.marioPause){
                game.marioPause = false;
            }
            else {
                game.marioPause = true;
            }
        }
    }
}
