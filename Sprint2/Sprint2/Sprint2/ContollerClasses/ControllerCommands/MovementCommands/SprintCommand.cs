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
            ((Mario)Game.mario).rigidbody.Elasticity = UtilityClass.restoreElasticity;
            ((Mario)Game.mario).rigidbody.AirFriction = UtilityClass.restoreAirFriction;
            ((Mario)Game.mario).rigidbody.GroundFriction = UtilityClass.restoreGroundFriction;
            ((Mario)Game.mario).rigidbody.maxVelocityX = UtilityClass.sprintMaxVelocityX;
            ((Mario)Game.mario).rigidbody.maxVelocityY = UtilityClass.sprintMaxVelocityY;
            ((Mario)Game.mario).rigidbody.GroundSpeed = UtilityClass.sprintGrounndSpeed;
            ((Mario)Game.mario).rigidbody.JumpSpeed = UtilityClass.sprintJumpSpeed;
            ((Mario)Game.mario).rigidbody.JumpDuration = UtilityClass.sprintJumpDuration;
        }
    }
}
