using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IansCSharpGame
{
    public class GamepadController : IController
    {
        public Boolean QWasPressed { get { return QWasPressed; } set { QWasPressed = value; } }
        public Boolean WWasPressed { get { return WWasPressed; } set { WWasPressed = value; } }
        public Boolean EWasPressed { get { return EWasPressed; } set { EWasPressed = value; } }
        public Boolean RWasPressed { get { return RWasPressed; } set { RWasPressed = value; } }
        //Basically just searches for any gamepad input, is called at every iteration of Update in the Game class.
        //I don't have access to a GamePad right now so this is left as pseudocode for now.
        public void Update() 
        {
            //If(BackButtonPressed) { QuitGameCommand(); }
            //If(StartButtonPressed) { OpenGameMenuCommand(); }
            //If(XButtonPressed) { WalkingSpriteCommand(); }
            //If(YButtonPressed) { DeadMarioSpriteCommand(); }
            //Etc...
        }
    }
}
