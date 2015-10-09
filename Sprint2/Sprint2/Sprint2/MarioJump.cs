using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    class MarioJump: IPlayerState
    {
        private Mario mario;
        private AnimatedSprite big;
        private AnimatedSprite small;
        private AnimatedSprite fire;
        public MarioJump(Mario mario)
        {
            this.mario = mario;
            big = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigJumpingSprite(mario.facingRight), 1, 1, mario.location);
            small = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallJumpingSprite(mario.facingRight), 1, 1,mario.location);
            fire = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigJumpingSprite(mario.facingRight), 1, 1,mario.location);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (mario.fire)
                fire.Draw(spriteBatch,mario.location);
            else if (mario.small)
                small.Draw(spriteBatch,mario.location);
            else
                big.Draw(spriteBatch,mario.location);
           
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

        public Rectangle returnStateCollisionRectangle()
        {
            Rectangle collisionRectangle;

            if (mario.small)
            {
                collisionRectangle = small.returnCollisionRectangle();
            }
            else if(mario.fire)
            {
                collisionRectangle = fire.returnCollisionRectangle();
            }
            else
            {
                collisionRectangle = big.returnCollisionRectangle();
            }

            return collisionRectangle;
        }
    }
}
