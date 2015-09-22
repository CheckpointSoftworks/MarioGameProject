using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KrisWengersSprint0
{
    class MarioDuck: IPlayerState
    {
        private Mario mario;
        public MarioDuck(Mario mario)
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
            //Do nothing, maybe stand up?
        }
        public void ChangeDirection()
        {
            //Do nothing, invalid
        }
        public void Jump()
        {
            // Nothing for now, but duck jump may exist
        }
        public void ShootFireball()
        {
            if (mario.fire)
            mario.state = new MarioShootFireball(mario);
        }
        public void Duck()
        {
            // Nothing
        }
        public void Dying()
        {
            mario.state = new MarioDying(mario);
        }
    }
}
