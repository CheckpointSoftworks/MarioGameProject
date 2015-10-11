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

        public KeyNotPressed(Game1 gameInstance)
        {
            game = gameInstance;
            leftThumbPosition.X = 0;
            leftThumbPosition.Y = 0;
        }

        public void Execute()
        {
            GamePadState padState1 = GamePad.GetState(PlayerIndex.One);
            leftThumbPosition.X = padState1.ThumbSticks.Left.X;
            leftThumbPosition.Y = padState1.ThumbSticks.Left.Y;

            KeyboardState currentState=Keyboard.GetState();
            if (currentState.IsKeyUp(Keys.A) && currentState.IsKeyUp(Keys.D)
                && currentState.IsKeyUp(Keys.W) && currentState.IsKeyUp(Keys.S)
                && currentState.IsKeyUp(Keys.Up) && currentState.IsKeyUp(Keys.Down) 
                && currentState.IsKeyUp(Keys.Left) && currentState.IsKeyUp(Keys.Right)
                && (leftThumbPosition.X < 0.5f && leftThumbPosition.X > -0.5f)
                && (leftThumbPosition.Y < 0.5f && leftThumbPosition.Y > -0.5f))
            {
                ((Mario)game.mario).State.Still();
            }
        }
    }
}
