using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class CameraControllerCommand:ICommand
    {
        private Game1 game;

        public CameraControllerCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.cameraController = new CameraController(game.camera, game.mario);
        }
    }
}
