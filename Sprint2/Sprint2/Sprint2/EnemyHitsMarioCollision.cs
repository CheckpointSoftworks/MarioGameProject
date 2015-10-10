using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class EnemyHitsMarioCollision:ICommand
    {
        private Mario mario;

        public EnemyHitsMarioCollision(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.State.Dying();
        }
    }
}
