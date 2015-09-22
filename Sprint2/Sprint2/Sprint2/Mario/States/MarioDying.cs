using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KrisWengersSprint0
{
    class MarioDying: IPlayerState
    {
        private Mario mario;
        public MarioDying(Mario mario)
        {
            this.mario = mario;
            //Set Sprite here
        }
        public void Still()
        {
            //Nothing, death consumes all
        }
        public void Running()
        {
            //Nothing, death consumes all
        }
        public void ChangeDirection()
        {
            //Nothing, death consumes all
        }
        public void Jump()
        {
            //Nothing, death consumes all
        }
        public void ShootFireball()
        {
            //Nothing, death consumes all
        }
        public void Duck()
        {
            //Nothing, death consumes all
        }
        public void Dying()
        {
            //Nothing, death consumes all
        }
    }
}
