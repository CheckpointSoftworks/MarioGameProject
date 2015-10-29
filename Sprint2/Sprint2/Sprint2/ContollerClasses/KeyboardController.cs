using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Sprint2
{
    public class KeyboardController : IController
    {
        private ICommand left;
        private ICommand right;
        private ICommand up;
        private ICommand down;
        private ICommand leftDown;
        private ICommand rightDown;
        private ICommand leftUp;
        private ICommand rightUp;
        private ICommand fireball;
        private ICommand reset;
        private ICommand sprint;
        private ICommand restoreRigidbody;
        KeyboardState keyState;

        public KeyboardController(Game1 game)
        {
            left = new LeftCommand(game);
            right = new RightCommand(game);
            up = new UpCommand(game);
            down = new DownCommand(game);
            leftDown = new LeftDownCommand(game);
            rightDown = new RightDownCommand(game);
            fireball = new FireballCommand(game);
            sprint = new SprintCommand(game);
            restoreRigidbody = new RestoreMarioRigidbodyCommand(game);
            reset = new ResetLevelCommand(game);
        }

        public void Update()
        {
            keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Left) && keyState.IsKeyUp(Keys.Down))
            {
                left.Execute();
            }
            if (keyState.IsKeyDown(Keys.Right) && keyState.IsKeyUp(Keys.Down))
            {
                right.Execute();
            }
            if (keyState.IsKeyDown(Keys.Z))
            {
                up.Execute();
            }
            if (keyState.IsKeyDown(Keys.Down))
            {
                down.Execute();
            }
            if (keyState.IsKeyDown(Keys.Left) && keyState.IsKeyDown(Keys.Down))
            {
                leftDown.Execute();
            }
            if (keyState.IsKeyDown(Keys.Right) && keyState.IsKeyDown(Keys.Down))
            {
                rightDown.Execute();
            }
            if (keyState.IsKeyDown(Keys.X))
            {
                fireball.Execute();
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                sprint.Execute();
            }
            if (keyState.IsKeyUp(Keys.A) && GamePad.GetState(PlayerIndex.One).IsButtonUp(Buttons.A))
            {
                restoreRigidbody.Execute();
            }
            if (keyState.IsKeyDown(Keys.R))
            {
                reset.Execute();
            }
        }
    }
}
