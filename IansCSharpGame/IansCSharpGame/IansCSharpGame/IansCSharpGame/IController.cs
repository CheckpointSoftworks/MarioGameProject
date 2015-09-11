using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IansCSharpGame
{
    interface IController
    {
        Boolean QWasPressed { get; set; }
        Boolean WWasPressed { get; set; }
        Boolean EWasPressed { get; set; }
        Boolean RWasPressed { get; set; } 
        void Update(); //Searches for keyboard or gamepad input.
    }
}
