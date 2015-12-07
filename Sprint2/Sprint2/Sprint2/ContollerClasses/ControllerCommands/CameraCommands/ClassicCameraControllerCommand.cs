using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class ClassicCameraControllerCommand:ICommand
    {
        private Game1 game;

        public ClassicCameraControllerCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.cameraController = new ClassicCameraController(game.camera, game.mario);
        }
    }
}
