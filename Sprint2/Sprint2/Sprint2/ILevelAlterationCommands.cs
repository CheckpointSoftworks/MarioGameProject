using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public interface ILevelAlterationCommands
    {
        void setGame(Game1 game);

        void Execute();
    }
}
