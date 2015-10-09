using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
     class MarioChangeDirection: IPlayerState
    {
        private Mario mario;
        private AnimatedSprite smallSprite;
        private AnimatedSprite bigSprite;
        private AnimatedSprite fireSprite;
        public MarioChangeDirection(Mario mario)
        {
            this.mario = mario;
            mario.facingRight = !mario.facingRight;
            bigSprite = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigStillSprite(mario.facingRight), 1, 1, mario.location);
            smallSprite = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallStillSprite(mario.facingRight), 1, 1, mario.location);
            fireSprite = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigJumpingSprite(mario.facingRight), 1, 1, mario.location);
            //Set Sprite here
        }
        public void Draw(SpriteBatch spriteBatch)
        {

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

