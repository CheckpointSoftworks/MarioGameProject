using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class ShakyCameraControllerCommand:ICommand
    {
        private Game1 game;

        public ShakyCameraControllerCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.cameraController = new ShakyCameraController(game.camera, game.mario);
        }
    }
}
