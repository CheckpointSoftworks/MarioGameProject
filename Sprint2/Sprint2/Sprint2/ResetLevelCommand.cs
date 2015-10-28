using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class ResetLevelCommand:ICommand
    {
        private Game1 game;
        public ResetLevelCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.camera = new Camera(480, 800, new Vector2(0, 0));
            game.loader= new LevelLoader("Level.xml", game.camera);
            game.levelStore = game.loader.LoadLevel();
        }
    }
}
