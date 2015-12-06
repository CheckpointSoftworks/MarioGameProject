using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public static class AchievementPause
    {

        private static Game1 game;

        public static void setGame(Game1 sentGame)
        {
            game = sentGame;
        }

        public static void Execute()
        {
            ICommand pause=new PauseCommand(game);
            pause.Execute();
        }
    }
}
