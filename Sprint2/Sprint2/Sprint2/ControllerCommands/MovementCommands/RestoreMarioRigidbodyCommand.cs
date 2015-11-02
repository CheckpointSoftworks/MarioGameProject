using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class RestoreMarioRigidbodyCommand : ICommand
    {
        private Game1 Game;

        public RestoreMarioRigidbodyCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            ((Mario)Game.mario).rigidbody.Elasticity = 0.0f;
            ((Mario)Game.mario).rigidbody.AirFriction = 0.95f;
            ((Mario)Game.mario).rigidbody.GroundFriction = 0.7f;
            ((Mario)Game.mario).rigidbody.maxVelocityX = 12.0f;
            ((Mario)Game.mario).rigidbody.maxVelocityY = 6.0f;
            ((Mario)Game.mario).rigidbody.GroundSpeed = 6.0f;
            ((Mario)Game.mario).rigidbody.JumpSpeed = -48.0f;
            ((Mario)Game.mario).rigidbody.JumpDuration = 1.6f;
            ((Mario)Game.mario).rigidbody.IsEnabled = true;
        }
    }
}
