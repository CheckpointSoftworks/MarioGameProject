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
        private Dictionary<Keys, ICommand> releasedControllerMappings;

        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            releasedControllerMappings = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void RegisterReleasedCommand(Keys key, ICommand command)
        {
            releasedControllerMappings.Add(key, command);
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
                if (controllerMappings[key].Equals(Keys.X))
                {
                        controllerMappings[key].Execute();
                }
                else if (!controllerMappings[key].Equals(Keys.X))
                {
                    controllerMappings[key].Execute();
                }
            }
            if (!keyList.Contains(Keys.Z))
            {
                releasedControllerMappings[Keys.Z].Execute();
            }
            if (!keyList.Contains(Keys.X))
            {
                releasedControllerMappings[Keys.X].Execute();
            }
        }
    }
}
