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
            big = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigJumpingSprite(), 1, 1);
            small = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallJumpingSprite(), 1, 1);
            fire = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireJumpingSprite(), 1, 1);
        }
        public void Update()
        {
            if (mario.fire)
            {
                fire.Update();
            }
            else if (mario.small)
            {
                small.Update();
            }
            else
            {
                big.Update();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (mario.fire)
                fire.Draw(spriteBatch, mario.location, mario.facingRight);
            else if (mario.small)
                small.Draw(spriteBatch,mario.location, mario.facingRight);
            else
                big.Draw(spriteBatch, mario.location, mario.facingRight);
           
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
            mario.state = new MarioStill(mario);
        }
        public void Dying()
        {
            mario.state = new MarioDying(mario);
        }
    }
}
