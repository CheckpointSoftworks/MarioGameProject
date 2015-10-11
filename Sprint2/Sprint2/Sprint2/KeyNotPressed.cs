using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    class KeyNotPressed : ICommand
    {
        private Game1 game;

        public KeyNotPressed(Game1 gameInstance)
        {
            game = gameInstance;
        }

        public void Execute()
        {
            KeyboardState currentState=Keyboard.GetState();
            if (currentState.IsKeyUp(Keys.A) && currentState.IsKeyUp(Keys.D)
                && currentState.IsKeyUp(Keys.W) && currentState.IsKeyUp(Keys.S)&& currentState.IsKeyUp(Keys.Up)
                && currentState.IsKeyUp(Keys.Down)&&currentState.IsKeyUp(Keys.Left)&&currentState.IsKeyUp(Keys.Right))
            {
                ((Mario)game.mario).State.Still();
            }
        }
    }
}
