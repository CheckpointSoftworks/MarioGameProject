using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    public interface IKeyboard
    {       
        void RegisterCommand(Keys key,ICommand command);
        void Update();
    }
}
