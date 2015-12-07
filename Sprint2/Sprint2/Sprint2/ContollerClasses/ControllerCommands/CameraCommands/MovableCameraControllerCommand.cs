using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class MovableCameraControllerCommand:ICommand
    {
        private Game1 game;

        public MovableCameraControllerCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.cameraController = new MovableCameraController(game.camera, game.mario, (GamepadController)game.gamepad, 100);
        }
    }
}
