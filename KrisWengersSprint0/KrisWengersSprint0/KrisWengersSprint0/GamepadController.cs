using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class GamepadController : IController
    {
        public Game1 Game { get; set; }
        public GamepadController(Game1 game)
        {
            Game = game;
        }
        public void Update()
        {
            GamePadState currentstate = GamePad.GetState(PlayerIndex.One);
            if (currentstate.IsConnected)
            {
                if (currentstate.Buttons.Start==ButtonState.Pressed)
                {
                    Game.Exit();
                }
                else if (currentstate.Buttons.A == ButtonState.Pressed)
                {
                    Game.marioSprite = new RunningInPlaceMario(Game.Content);
                }
                else if (currentstate.Buttons.B == ButtonState.Pressed)
                {
                    Game.marioSprite = new DeadFloatingMario(Game.Content);
                }
                else if (currentstate.Buttons.X == ButtonState.Pressed)
                {
                    Game.marioSprite = new RunningRightMario(Game.Content);
                }
            }
        }
    }
}
