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
        private List<Keys> checkReleasedKeyList;        

        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            releasedControllerMappings = new Dictionary<Keys, ICommand>();
            checkReleasedKeyList = new List<Keys>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void RegisterReleasedCommand(Keys key, ICommand command)
        {
            releasedControllerMappings.Add(key, command);
            checkReleasedKeyList.Add(key);
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

            foreach (Keys k in checkReleasedKeyList.ToArray())
            {
                if (!keyList.Contains(k))
                {
                    releasedControllerMappings[k].Execute();
                }
            }
        
            
        }
    }
}
