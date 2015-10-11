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
        GamePadState padState1;
        Vector2 leftThumbPosition;
        ICommand leftOnlyCommand;
        ICommand rightOnlyCommand;
        ICommand upOnlyCommand;
        ICommand downOnlyCommand;
        ICommand upLeftCommand;
        ICommand upRightCommand;
        ICommand downLeftCommand;
        ICommand downRightCommand;

        public GamepadController (Game1 game)
        {
            leftThumbPosition.X = 0;
            leftThumbPosition.Y = 0;
            leftOnlyCommand = new LeftCommand(game);
            rightOnlyCommand = new RightCommand(game);
            upOnlyCommand = new UpCommand(game);
            downOnlyCommand = new DownCommand(game);
            //upLeftCommand = new UpLeftCommand(game);
            //upRightCommand = new UpRightCommand(game);
            //downLeftCommand = new DownLeftCommand(game);
            //downRightCommand = new DownRightCommand(game);
        }

        public void Update()
        {
            padState1 = GamePad.GetState(PlayerIndex.One);

            if (padState1.IsConnected)
            {
                leftThumbPosition.X = padState1.ThumbSticks.Left.X;
                leftThumbPosition.Y = padState1.ThumbSticks.Left.Y;

                if (leftThumbPosition.X > 0.5f && (leftThumbPosition.Y < 0.5f && leftThumbPosition.Y > -0.5f))
                {
                    rightOnlyCommand.Execute();
                }

                if (leftThumbPosition.X < -0.5f && (leftThumbPosition.Y < 0.5f && leftThumbPosition.Y > -0.5f))
                {
                    leftOnlyCommand.Execute();
                }

                if (leftThumbPosition.Y > 0.5f && (leftThumbPosition.X < 0.5f && leftThumbPosition.X > -0.5f))
                {
                    upOnlyCommand.Execute();
                }

                if (leftThumbPosition.Y < -0.5f && (leftThumbPosition.X < 0.5f && leftThumbPosition.X > -0.5f))
                {
                    downOnlyCommand.Execute();
                }
            }
        }
    }
}
