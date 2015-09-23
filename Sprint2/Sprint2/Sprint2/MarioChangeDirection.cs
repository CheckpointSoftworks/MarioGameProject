using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
     class MarioChangeDirection: IPlayerState
    {
        private Mario mario;
        public MarioChangeDirection(Mario mario)
        {
            this.mario = mario;
            mario.facingRight = !mario.facingRight;
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
            //Nothing
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

