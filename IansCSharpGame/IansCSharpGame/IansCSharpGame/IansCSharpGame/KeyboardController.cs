using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace IansCSharpGame
{
    public class KeyboardController : IController
    {
        private Boolean qWasPressed;
        private Boolean wWasPressed;
        private Boolean eWasPressed;
        private Boolean rWasPressed;
        public Boolean QWasPressed { get { return qWasPressed; } set { qWasPressed = value; } }  
        public Boolean WWasPressed { get { return wWasPressed; } set { wWasPressed = value; } }
        public Boolean EWasPressed { get { return eWasPressed; } set { eWasPressed = value; } }
        public Boolean RWasPressed { get { return rWasPressed; } set { rWasPressed = value; } }
        public void Update()
        {
            KeyboardState newState = Keyboard.GetState();
            if(newState.IsKeyDown(Keys.Q))      { QWasPressed=true; WWasPressed=false; EWasPressed=false; RWasPressed=false;}
            else if(newState.IsKeyDown(Keys.W)) { WWasPressed=true; QWasPressed=false; EWasPressed=false; RWasPressed=false;}
            else if(newState.IsKeyDown(Keys.E)) { EWasPressed=true; QWasPressed=false; RWasPressed=false; WWasPressed=false;}
            else if(newState.IsKeyDown(Keys.R)) { RWasPressed=true; QWasPressed=false; EWasPressed=false; WWasPressed=false;}
        }

        public KeyboardController()
        {
            this.QWasPressed = false;
            this.WWasPressed = false;
            this.EWasPressed = false;
            this.RWasPressed = false;
        }
    }
}
