using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Sprint2
{
    public class GamepadController : IController
    {
        private GamePadState padState1;
        private Vector2 leftThumbPosition;
        private ICommand left;
        private ICommand right;
        private ICommand up;
        private ICommand down;
        private ICommand fireball;
        private ICommand sprint;
        private bool alreadyShot;
        private float deadZone;

        public GamepadController(Game1 game)
        {
            leftThumbPosition.X = 0;
            leftThumbPosition.Y = 0;
            deadZone = 0.5f;

            left = new LeftCommand(game);
            right = new RightCommand(game);
            up = new UpCommand(game);
            down = new DownCommand(game);
            fireball = new FireballCommand(game);
            sprint = new SprintCommand(game);
        }

        public void Update()
        {
            padState1 = GamePad.GetState(PlayerIndex.One);

            if (padState1.IsConnected)
            {
                leftThumbPosition.X = padState1.ThumbSticks.Left.X;
                leftThumbPosition.Y = padState1.ThumbSticks.Left.Y;

                if (leftThumbPosition.X < -deadZone && (leftThumbPosition.Y < deadZone && leftThumbPosition.Y > -deadZone))
                {
                    left.Execute();
                }
                if (leftThumbPosition.X > deadZone && (leftThumbPosition.Y < deadZone && leftThumbPosition.Y > -deadZone))
                {
                    right.Execute();
                }
                if (leftThumbPosition.Y > deadZone && (leftThumbPosition.X < deadZone && leftThumbPosition.X > -deadZone))
                {
                    up.Execute();
                }
                if (leftThumbPosition.Y < -deadZone && (leftThumbPosition.X < deadZone && leftThumbPosition.X > -deadZone))
                {
                    down.Execute();
                }
                if (padState1.Buttons.X == ButtonState.Pressed)
                {
                    if (!alreadyShot)
                    {
                        fireball.Execute();
                    }
                    alreadyShot = true;
                }
                else
                {
                    alreadyShot = false;
                }
                if (padState1.Buttons.A == ButtonState.Pressed)
                {
                    sprint.Execute();
                }
            }
        }
    }
}
