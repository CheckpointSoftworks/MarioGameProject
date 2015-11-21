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
            game.camera = new Camera(UtilityClass.cameraHeight, UtilityClass.cameraWidth, new Vector2(UtilityClass.zero, UtilityClass.zero));
            game.loader = new LevelLoader(UtilityClass.levelFile, game.camera);
            game.levelStore = new LevelStorage(game.camera);
            game.levelStore = game.loader.LoadLevel();
            game.mario = game.levelStore.player;
            game.cameraController = new CameraController(game.camera, game.mario);
            game.pause = false;
            MusicFactory.MainTheme();
            game.ResetTime();
            game.hitFlagpole = false;
            game.flag = new Flag();
            game.gui = new GUI();
            game.ResetGui();
        }
    }
}
