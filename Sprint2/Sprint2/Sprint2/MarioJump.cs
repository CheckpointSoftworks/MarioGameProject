using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class MarioJump: IPlayerState
    {
        private Mario mario;
        public MarioJump(Mario mario)
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
            //Do Nothing
        }
        public void ShootFireball()
        {
            if (mario.fire)
            mario.state = new MarioShootFireball(mario);
        }
        public void Duck()
        {
            //Do nothing, Jump -> Duck is invalid
        }
        public void Dying()
        {
            mario.state = new MarioDying(mario);
        }
    }
}
