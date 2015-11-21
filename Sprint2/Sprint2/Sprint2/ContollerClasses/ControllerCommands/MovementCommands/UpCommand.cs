using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class UpCommand: ICommand
    {
            private Game1 Game;

            public UpCommand(Game1 game)
            {
                Game = game;
            }

            public void Execute()
            {
                if (((Mario)Game.mario).rigidbody.Floored) { 
                    if (((Mario)Game.mario).Small)
                    {
                        SoundEffectFactory.JumpSmall();
                    }
                    else
                    {
                        SoundEffectFactory.JumpBig();
                    }
                }
                ((Mario)Game.mario).Jump();
            }
    }
}
