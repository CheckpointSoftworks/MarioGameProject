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
            ((Mario)Game.mario).rigidbody.Elasticity = UtilityClass.restoreElasticity;
            ((Mario)Game.mario).rigidbody.AirFriction = UtilityClass.restoreAirFriction;
            ((Mario)Game.mario).rigidbody.GroundFriction = UtilityClass.restoreGroundFriction;
            ((Mario)Game.mario).rigidbody.maxVelocityX = UtilityClass.restoreMaxelocityX;
            ((Mario)Game.mario).rigidbody.maxVelocityY = UtilityClass.restoreMaxVelocityY;
            ((Mario)Game.mario).rigidbody.GroundSpeed = UtilityClass.restoreGroundSpeed;
            ((Mario)Game.mario).rigidbody.JumpSpeed = UtilityClass.restoreJumpSpeed;
            ((Mario)Game.mario).rigidbody.JumpDuration = UtilityClass.restoreJumpDuration;
            ((Mario)Game.mario).rigidbody.IsEnabled = true;
        }
    }
}
