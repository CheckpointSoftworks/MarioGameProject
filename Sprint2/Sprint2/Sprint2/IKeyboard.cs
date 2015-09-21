using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    interface IKeyboard
    {
        //Each keyboard button causes an object to appear on the screen for sprint2 based on the previous state.
        void SmallMarioPressed { get; set; }
        void BigMarioPressed { get; set; }
        void FireMarioPressed { get; set; }
        void DeadMarioPressed { get; set; }
        void ResetPressed { get; set; }
        void LeftPressed { get; set; } //Changes mario to face left, idle.
        void RightPressed { get; set; }
        void UpPressed { get; set; }
        void DownPressed { get; set; }
        void QuestionBlockToUsedBlock { get; set; }
        void BrickBlockDisappears { get; set; }
        void HiddenBlockToUsedBlock { get; set; }
        
        void Update();
    }
}
