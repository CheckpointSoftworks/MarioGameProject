using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public static class AchievementUnPauser
    {
        private static Game1 game;

        public static void setGame(Game1 sentGame)
        {
            game = sentGame;
        }

        public static void Execute()
        {
            if (game.pause)
            {
                ICommand unPause = new PauseCommand(game);
                unPause.Execute();
            }
        }
    }
}
