using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class PauseCommand:ICommand
    {
        private LevelStorage level;
        public PauseCommand(LevelStorage level)
        {
            this.level = level;
        }

        public void Execute()
        {
            level.pauseGame();
        }
    }
}
