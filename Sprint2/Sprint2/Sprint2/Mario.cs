using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class Mario 
    {
        public bool facingRight;
        public bool small;
        public bool falling;
        public bool fire;
        public bool star;
        public float velX;
        public float velY;
        public IPlayerState state;
        public Mario()
        {
            state = new MarioStill(this);
        }
        void Still()
        {
            state.Still();
        }
        void Running()
        {
            state.Running();
        }
        void ChangeDirection()
        {
            state.ChangeDirection();
        }
        void Jump()
        {
            state.Jump();
        }
        void ShootFireball()
        {
            state.ShootFireball();
        }
        void Duck()
        {
            state.Duck();
        }
        void Dying()
        {
            state.Dying();
        }
    }
}
