using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    class MarioRunning: IPlayerState
    {
        private Mario mario;
        AnimatedSprite small;
        AnimatedSprite big;
        AnimatedSprite fire;
        public MarioRunning(Mario mario)
        {
            this.mario = mario;
            big = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigRunningSprite(), 1, 3);
            small = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallRunningSprite(), 1, 3);
            fire = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireRunningSprite(), 1, 3);
            //Set Sprite here
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
            {
                fire.Draw(spriteBatch, mario.location, mario.facingRight);
            }
            else if (mario.small)
            {
                small.Draw(spriteBatch, mario.location, mario.facingRight);
            }
            else
            {
                big.Draw(spriteBatch, mario.location, mario.facingRight);
            }
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
            mario.state = new MarioJump(mario);   
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