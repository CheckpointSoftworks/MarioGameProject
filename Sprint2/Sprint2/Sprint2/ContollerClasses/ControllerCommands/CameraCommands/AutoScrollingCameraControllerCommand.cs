using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class AutoScrollingCameraControllerCommand:ICommand
    {
        private Game1 game;

        public AutoScrollingCameraControllerCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.cameraController = new AutoScrollingCameraController(game.camera, game.mario, 1);
        }
    }
}
