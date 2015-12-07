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
            if (game.returnCanPause())
            {
                if (!game.returnPause()) {
                    SoundEffectFactory.Pause();
                    game.setPause(true);
                    game.setCanPause(false);
                }
                else {
                    game.setPause(false);
                    game.setCanPause(false);
                }
            }
        }
    }
}
