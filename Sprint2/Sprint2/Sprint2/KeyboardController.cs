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

        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            ArrayList keyList = new ArrayList();

            foreach (Keys key in pressedKeys)
            {
                //Calls the Execute method in the command object corresponding to the pressed key.
                if (controllerMappings.ContainsKey(key))
                {
                    keyList.Add(key);
                    //controllerMappings[key].Execute();
                }
            }
            foreach (Keys key in keyList)
            {
                if ((keyList.Contains(Keys.W) && (keyList.Contains(Keys.D) || keyList.Contains(Keys.A)))||(keyList.Contains(Keys.Up)&&(keyList.Contains(Keys.Right)||keyList.Contains(Keys.Left))))
                {
                    //call up diagonal command
                }
                else if ((keyList.Contains(Keys.S) && (keyList.Contains(Keys.D) || keyList.Contains(Keys.A))) || (keyList.Contains(Keys.Down) && (keyList.Contains(Keys.Right) || keyList.Contains(Keys.Left))))
                {
                    //call down diagonal command
                }
                else
                {
                    controllerMappings[key].Execute();
                }
            }
        }
    }
}
