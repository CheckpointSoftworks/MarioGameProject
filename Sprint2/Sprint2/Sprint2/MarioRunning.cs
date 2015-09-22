using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KrisWengersSprint0
{
    class MarioRunning: IPlayerState
    {
        private Mario mario;
        public MarioRunning(Mario mario)
        {
            this.mario = mario;
            //Set Sprite here
        }
        public void Still()
        {
            mario.state = new MarioStill(mario);
        }
        public void Running()
        {
            //Do Nothing
        }
        public void ChangeDirection()
        {
            mario.state = new MarioChangeDirection(mario);
        }
        public void Jump()
        {
            mario.state = new MarioChangeDirection(mario);
        }
        public void ShootFireball()
        {
            if (mario.fire)
            mario.state = new MarioShootFireball(mario);
        }
        public void Duck()
        {
            mario.state = new MarioDuck(mario);
        }
        public void Dying()
        {
            mario.state = new MarioDying(mario);
        }
    }

}