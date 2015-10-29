using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class SprintCommand : ICommand
    {
        private Game1 Game;

        public SprintCommand(Game1 game)
        {
            Game = game;
        }

        public void Execute()
        {
            ((Mario)Game.mario).rigidbody.Elasticity = 0.0f;
            ((Mario)Game.mario).rigidbody.AirFriction = 0.95f;
            ((Mario)Game.mario).rigidbody.GroundFriction = 0.7f;
            ((Mario)Game.mario).rigidbody.maxVelocityX = 22.8f;
            ((Mario)Game.mario).rigidbody.maxVelocityY = 11.4f;
            ((Mario)Game.mario).rigidbody.GroundSpeed = 11.4f;
            ((Mario)Game.mario).rigidbody.JumpSpeed = -48.0f;
            ((Mario)Game.mario).rigidbody.JumpDuration = 1.65f;
        }
    }
}
