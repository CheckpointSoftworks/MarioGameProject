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
            if (Keyboard.GetState().IsKeyUp(Keys.A) && Keyboard.GetState().IsKeyUp(Keys.D)
                && Keyboard.GetState().IsKeyUp(Keys.W) && Keyboard.GetState().IsKeyUp(Keys.S))
            {
                ((Mario)game.mario).State.Still();
            }
        }
    }
}
