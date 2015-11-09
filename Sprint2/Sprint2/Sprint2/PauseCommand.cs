using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public static class PauseCommand
    {
        private static LevelStorage level;

        public static void setGame(LevelStorage sentLevel)
        {
            level = sentLevel;
        }

        public static void Execute()
        {
            level.pauseGame();
        }
    }
}
