using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class DrunkCameraControllerCommand:ICommand
    {
        private Game1 game;

        public DrunkCameraControllerCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.cameraController = new DrunkCameraController(game.camera, game.mario, 60, 3);
        }
    }
}
