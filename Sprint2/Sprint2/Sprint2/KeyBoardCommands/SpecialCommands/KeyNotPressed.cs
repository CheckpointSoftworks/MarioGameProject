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
        private Vector2 leftThumbPosition;
        private KeyboardState keyState;
        private GamePadState padState1;
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
           keyState = Keyboard.GetState();

            return keyState.IsKeyUp(Keys.W) && keyState.IsKeyUp(Keys.S)
                && keyState.IsKeyUp(Keys.A) && keyState.IsKeyUp(Keys.D)
                && keyState.IsKeyUp(Keys.Up) && keyState.IsKeyUp(Keys.Down)
                && keyState.IsKeyUp(Keys.Left) && keyState.IsKeyUp(Keys.Right);
        }

        public bool LeftStickInDeadzone()
        {
            padState1 = GamePad.GetState(PlayerIndex.One);
            leftThumbPosition.X = padState1.ThumbSticks.Left.X;
            leftThumbPosition.Y = padState1.ThumbSticks.Left.Y;

            if (padState1.IsConnected)
            {
                return (leftThumbPosition.X < deadZone && leftThumbPosition.X > -deadZone)
                    && (leftThumbPosition.Y < deadZone && leftThumbPosition.Y > -deadZone);
            }
            else
            {
                return true;
            }

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
