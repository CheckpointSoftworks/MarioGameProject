using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
  
namespace KrisWengersSprint0
{  
    class MarioShootFireball: IPlayerState
    {
        private Mario mario;
        public MarioShootFireball(Mario mario)
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
            mario.state = new MarioRunning(mario);
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
            //Nothing
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
