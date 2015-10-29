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
            ((Mario)Game.mario).rigidbody.Elasticity = 0f;
            ((Mario)Game.mario).rigidbody.AirFriction = 1f;
            ((Mario)Game.mario).rigidbody.GroundFriction = 0.7f;
            ((Mario)Game.mario).rigidbody.maxVelocityX = 20;
            ((Mario)Game.mario).rigidbody.maxVelocityY = 10;
            ((Mario)Game.mario).rigidbody.GroundSpeed = 10;
            ((Mario)Game.mario).rigidbody.JumpSpeed = -65;
            ((Mario)Game.mario).rigidbody.JumpDuration = 1;
        }
    }
}
