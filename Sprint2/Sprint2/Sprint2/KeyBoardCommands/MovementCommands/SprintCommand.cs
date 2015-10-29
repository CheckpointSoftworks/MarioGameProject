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
            ((Mario)Game.mario).rigidbody.Elasticity = 0f;
            ((Mario)Game.mario).rigidbody.AirFriction = 1f;
            ((Mario)Game.mario).rigidbody.GroundFriction = 0.7f;
            ((Mario)Game.mario).rigidbody.maxVelocityX = 25;
            ((Mario)Game.mario).rigidbody.maxVelocityY = 15;
            ((Mario)Game.mario).rigidbody.GroundSpeed = 15;
            ((Mario)Game.mario).rigidbody.JumpSpeed = -70;
            ((Mario)Game.mario).rigidbody.JumpDuration = 2;
        }
    }
}
