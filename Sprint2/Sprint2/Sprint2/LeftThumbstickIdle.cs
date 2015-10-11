using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Sprint2
{
    class LeftThumbstickIdle : ICommand
    {
        private Game1 game;
        GamePadState padState1;
        Vector2 leftThumbPosition;

        public LeftThumbstickIdle(Game1 gameInstance)
        {
            game = gameInstance;
            leftThumbPosition.X = 0;
            leftThumbPosition.Y = 0;
        }

        public void Execute()
        {
            padState1 = GamePad.GetState(PlayerIndex.One);
            leftThumbPosition.X = padState1.ThumbSticks.Left.X;
            leftThumbPosition.Y = padState1.ThumbSticks.Left.Y;

            if (padState1.IsConnected)
            {
                if ((leftThumbPosition.X < 0.5f && leftThumbPosition.X > -0.5f) && 
                    (leftThumbPosition.Y < 0.5f && leftThumbPosition.Y > -0.5f))
                {
                    ((Mario)game.mario).State.Still();
                }
            }

            
        }

    }
}
