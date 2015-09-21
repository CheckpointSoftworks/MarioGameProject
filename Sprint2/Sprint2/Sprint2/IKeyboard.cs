using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    interface IKeyboard
    {
        Boolean QWasPressed { get; set; }
        Boolean WWasPressed { get; set; }
        Boolean EWasPressed { get; set; }
        Boolean RWasPressed { get; set; } 
        void Update();
    }
}
