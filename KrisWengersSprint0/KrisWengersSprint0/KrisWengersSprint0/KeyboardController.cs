using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class KeyboardController : IController
    {
        public Game1 Game { get; set; }
        
        public KeyboardController(Game1 game)
        {
            Game = game;
        }
        public void Update(){
            KeyboardState newState = Keyboard.GetState();

            if (newState.IsKeyDown(Keys.Q))
            {
                Game.Exit();
            }
            else if (newState.IsKeyDown(Keys.W))
            {
                Game.marioSprite = new RunningInPlaceMario(Game.Content);
            }
            else if (newState.IsKeyDown(Keys.E))
            {
                Game.marioSprite = new DeadFloatingMario(Game.Content);
            }
            else if (newState.IsKeyDown(Keys.R))
            {
                Game.marioSprite = new RunningRightMario(Game.Content);
            }

        }
    }
}
