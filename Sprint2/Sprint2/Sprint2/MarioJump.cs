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
            big = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigJumpingSprite(), 1, 1, mario.Location);
            small = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigJumpingSprite(), 1, 1, mario.Location);
            fire = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigJumpingSprite(), 1, 1, mario.Location);
        }
        public void Update()
        {
            if (mario.Fire)
            {
                fire.Update();
            }
            else if (mario.Small)
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
            if (mario.Fire)
                fire.Draw(spriteBatch, mario.Location, mario.FacingRight);
            else if (mario.Small)
                small.Draw(spriteBatch, mario.Location, mario.FacingRight);
            else
                big.Draw(spriteBatch, mario.Location, mario.FacingRight);

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
            //Do Nothing
        }
        public void ShootFireball()
        {
            if (mario.Fire)
                mario.State = new MarioShootFireball(mario);
        }
        public void Duck()
        {
            mario.State = new MarioStill(mario);
        }
        public void Dying()
        {
            mario.State = new MarioDying(mario);
        }

        public Rectangle returnStateCollisionRectangle()
        {
            Rectangle collisionRectangle;

            if (mario.Small)
            {
                collisionRectangle = small.returnCollisionRectangle();
            }
            else if(mario.Fire)
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
