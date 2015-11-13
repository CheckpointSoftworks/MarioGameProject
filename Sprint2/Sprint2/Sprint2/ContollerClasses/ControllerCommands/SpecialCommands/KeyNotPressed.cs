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
        private ICommand restoreRigidbody;
        private float deadZone;

        public KeyNotPressed(Game1 game)
        {
            this.game = game;
            leftThumbPosition.X = UtilityClass.zero;
            leftThumbPosition.Y = UtilityClass.zero;
            deadZone = UtilityClass.deadZone;
            restoreRigidbody = new RestoreMarioRigidbodyCommand(game);
        }

        public bool MovementKeysReleased()
        {
            return keyState.IsKeyUp(Keys.W) && keyState.IsKeyUp(Keys.S)
                && keyState.IsKeyUp(Keys.A) && keyState.IsKeyUp(Keys.D)
                && keyState.IsKeyUp(Keys.Up) && keyState.IsKeyUp(Keys.Down)
                && keyState.IsKeyUp(Keys.Left) && keyState.IsKeyUp(Keys.Right);
        }

        public bool LeftStickInDeadzone()
        {
            leftThumbPosition.X = padState1.ThumbSticks.Left.X;
            leftThumbPosition.Y = padState1.ThumbSticks.Left.Y;

            return (leftThumbPosition.X < deadZone && leftThumbPosition.X > -deadZone)
                && (leftThumbPosition.Y < deadZone && leftThumbPosition.Y > -deadZone);
            
        }

        public bool SprintKeyReleased()
        {
            return padState1.Buttons.A == ButtonState.Released && keyState.IsKeyUp(Keys.S)
                && keyState.IsKeyUp(Keys.S) && padState1.IsButtonUp(Buttons.A);
        }

        public void Execute()
        {
            padState1 = GamePad.GetState(PlayerIndex.One);
            keyState = Keyboard.GetState();

            if (SprintKeyReleased())
            {
                restoreRigidbody.Execute();
            }
            if (MovementKeysReleased() && LeftStickInDeadzone())
            {
                if (!((Mario)game.mario).State.Equals(MarioState.Die))
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
