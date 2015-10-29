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
        private Dictionary<Keys, ICommand> controllerMappings;
        private ICommand upRight;
        private ICommand upLeft;
        private ICommand downRight;
        private ICommand downLeft;

        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void RegisterDiagonalCommands(Game1 game)
        {
            upRight = new RightUpCommand(game);
            upLeft = new LeftUpCommand(game);
            downRight = new RightDownCommand(game);
            downLeft = new LeftDownCommand(game);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            ArrayList keyList = new ArrayList();

            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key))
                {
                    keyList.Add(key);
                }
            }
            foreach (Keys key in keyList)
            {
                controllerMappings[key].Execute();
            }
        }
    }
}
