using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class QuitCommand:ICommand
    {
        private Game1 game;
        public QuitCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            AchievementEventTracker.writeAchievements();
            game.Exit();
        }
    }
}
