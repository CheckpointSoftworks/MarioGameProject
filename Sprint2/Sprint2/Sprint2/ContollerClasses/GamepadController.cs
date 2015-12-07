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
        public GamePadState padState1;
        private Vector2 leftThumbPosition;
        private ICommand left;
        private ICommand right;
        private ICommand up;
        private ICommand down;
        private ICommand leftUp;
        private ICommand leftDown;
        private ICommand rightUp;
        private ICommand rightDown;
        private ICommand fireball;
        private ICommand sprint;
        private ICommand pause;
        private ICommand iceball;
        private bool fireballShot;
        private bool iceballShot;
        private bool alreadyPaused;
        private float deadZone;

        public GamepadController(Game1 game)
        {
            leftThumbPosition.X = UtilityClass.zero;
            leftThumbPosition.Y = UtilityClass.zero;
            deadZone = UtilityClass.deadZone;
            alreadyPaused = false;
            fireballShot = false;
            iceballShot = false;
            left = new LeftCommand(game);
            right = new RightCommand(game);
            up = new UpCommand(game);
            down = new DownCommand(game);
            leftUp = new LeftUpCommand(game);
            leftDown = new LeftDownCommand(game);
            rightUp = new RightUpCommand(game);
            rightDown = new RightDownCommand(game);
            fireball = new FireballCommand(game);
            sprint = new SprintCommand(game);
            pause = new GamepadPause(game);
            iceball = new IceballCommand(game);
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
                if (leftThumbPosition.X < -deadZone && leftThumbPosition.Y > deadZone)
                {
                    leftUp.Execute();
                }
                if (leftThumbPosition.X < -deadZone && leftThumbPosition.Y < -deadZone)
                {
                    leftDown.Execute();
                }
                if (leftThumbPosition.X > deadZone && leftThumbPosition.Y > deadZone)
                {
                    rightUp.Execute();
                }
                if (leftThumbPosition.X > deadZone && leftThumbPosition.Y < -deadZone)
                {
                    rightDown.Execute();
                }
                handleSpecialKeys();
            }
        }

        private void handleSpecialKeys()
        {
            
                if (padState1.Buttons.X == ButtonState.Pressed)
                {
                    if (!fireballShot)
                    {
                        fireball.Execute();
                    }
                    fireballShot = true;
                }
                else
                {
                    fireballShot = false;
                }
                if (padState1.Buttons.B == ButtonState.Pressed)
                {
                    if (!iceballShot)
                    {
                        iceball.Execute();
                    }
                    iceballShot = true;
                }
                else
                {
                    iceballShot = false;
                }
                if (padState1.Buttons.Start == ButtonState.Pressed)
                {
                    if (!alreadyPaused)
                    {
                        pause.Execute();
                    }
                    alreadyPaused = true;
                }
                else
                {
                    alreadyPaused = false;
                }
                if (padState1.Buttons.A == ButtonState.Pressed)
                {
                    sprint.Execute();
                }
        }
    }
}
