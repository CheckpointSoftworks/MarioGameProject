using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class PauseCommand:ICommand
    {
        private Game1 game;
        public PauseCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.canPause)
            {
                if (!game.pause) {
                    SoundEffectFactory.Pause();
                    game.pause = true;
                    game.canPause = false;
                }
                else { 
                    game.pause = false;
                    game.canPause = false;
                }
            }
        }
    }
}
