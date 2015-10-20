using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{  
    class MarioShootFireball: IMarioState
    {
        private Mario mario;
        public MarioShootFireball(Mario mario)
        {
            this.mario = mario;
        }
        public void Update()
        {
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
        }
        public void Still()
        {
            mario.State = new MarioStill(mario);
        }
        public void Running()
        {
            mario.State = new MarioRunning(mario);
        }
        public void ChangeDirection()
        {
            mario.State = new MarioChangeDirection(mario);
        }
        public void Jump()
        {
            mario.State = new MarioChangeDirection(mario);
        }
        public void JumpRun()
        {
            mario.State = new MarioJumpRun(mario);
        }
        public void ShootFireball()
        {
            
        }
        public void Duck()
        {
            mario.State = new MarioDuck(mario);
        }
        public void DuckRun()
        {
            mario.State = new MarioDuckRun(mario);
        }
        public void Dying()
        {
            mario.State = new MarioDying(mario);
        }

        public Rectangle returnStateCollisionRectangle()
        {
            Rectangle collisionRectangle=new Rectangle(0,0,0,0);

            

            return collisionRectangle;
        }
        public void setDrawColor(Color color)
        {
            
        }
    }
}
