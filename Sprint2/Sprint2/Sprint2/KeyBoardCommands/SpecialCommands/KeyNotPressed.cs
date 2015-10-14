using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Sprint2
{
    class KeyNotPressed : ICommand
    {
        private Game1 game;
        Vector2 leftThumbPosition;
        private float deadZone;

        public KeyNotPressed(Game1 gameInstance)
        {
            game = gameInstance;
            leftThumbPosition.X = 0;
            leftThumbPosition.Y = 0;
            deadZone = 0.5f;
        }

        public bool MovementKeysReleased()
        {
            KeyboardState currentState = Keyboard.GetState();

            return currentState.IsKeyUp(Keys.W) && currentState.IsKeyUp(Keys.S)
                && currentState.IsKeyUp(Keys.A) && currentState.IsKeyUp(Keys.D)
                && currentState.IsKeyUp(Keys.Up) && currentState.IsKeyUp(Keys.Down)
                && currentState.IsKeyUp(Keys.Left) && currentState.IsKeyUp(Keys.Right);
        }

        public bool LeftStickInDeadzone()
        {
            GamePadState padState1 = GamePad.GetState(PlayerIndex.One);
            leftThumbPosition.X = padState1.ThumbSticks.Left.X;
            leftThumbPosition.Y = padState1.ThumbSticks.Left.Y;

            return (leftThumbPosition.X < deadZone && leftThumbPosition.X > -deadZone)
                && (leftThumbPosition.Y < deadZone && leftThumbPosition.Y > -deadZone);

        }

        public void Execute()
        {
            if (MovementKeysReleased() && LeftStickInDeadzone())
            {
                if (!((Mario)game.mario).IsDying)
                {
                    ((Mario)game.mario).State.Still();
                }
                else if(!((Mario)game.mario).Star)
                {
                    ((Mario)game.mario).State.Dying();
                }
            }
        }
    }
}
