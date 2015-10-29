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
        private ICommand rightOnlyCommand;
        private ICommand leftOnlyCommand;
        private ICommand upOnlyCommand;
        private ICommand downOnlyCommand;
        private ICommand leftUpCommand;
        private ICommand leftDownCommand;
        private ICommand rightUpCommand;
        private ICommand rightDownCommand;
        private ICommand shootFireballCommand;
        private float deadZone;

        public GamepadController (Game1 game)
        {
            leftThumbPosition.X = 0;
            leftThumbPosition.Y = 0;
            rightOnlyCommand = new RightCommand(game);
            leftOnlyCommand = new LeftCommand(game);
            upOnlyCommand = new UpCommand(game);
            downOnlyCommand = new DownCommand(game);
            leftUpCommand = new LeftUpCommand(game);
            leftDownCommand = new LeftDownCommand(game);
            rightUpCommand = new RightUpCommand(game);
            rightDownCommand = new RightDownCommand(game);
            shootFireballCommand = new FireballCommand(game);
            deadZone = 0.5f;
        }

        public void Update()
        {
            padState1 = GamePad.GetState(PlayerIndex.One);

            if (padState1.IsConnected)
            {
                leftThumbPosition.X = padState1.ThumbSticks.Left.X;
                leftThumbPosition.Y = padState1.ThumbSticks.Left.Y;

                if (leftThumbPosition.X > deadZone && (leftThumbPosition.Y < deadZone && leftThumbPosition.Y > -deadZone))
                {
                    rightOnlyCommand.Execute();
                }

                if (leftThumbPosition.X < -deadZone && (leftThumbPosition.Y < deadZone && leftThumbPosition.Y > -deadZone))
                {
                    leftOnlyCommand.Execute();
                }

                if (leftThumbPosition.Y > deadZone && (leftThumbPosition.X < deadZone && leftThumbPosition.X > -deadZone))
                {
                    upOnlyCommand.Execute();
                }

                if (leftThumbPosition.Y < -deadZone && (leftThumbPosition.X < deadZone && leftThumbPosition.X > -deadZone))
                {
                    downOnlyCommand.Execute();
                }

                if (leftThumbPosition.X < -deadZone && leftThumbPosition.Y > deadZone)
                {
                    leftUpCommand.Execute();
                }

                if (leftThumbPosition.X < -deadZone && leftThumbPosition.Y < -deadZone)
                {
                    leftDownCommand.Execute();
                }

                if (leftThumbPosition.X > deadZone && leftThumbPosition.Y > deadZone)
                {
                    rightUpCommand.Execute();
                }

                if (leftThumbPosition.X > deadZone && leftThumbPosition.Y < -deadZone)
                {
                    rightDownCommand.Execute();
                }
                if (padState1.Buttons.X == ButtonState.Pressed)
                {
                    shootFireballCommand.Execute();
                }
            }
        }
    }
}
