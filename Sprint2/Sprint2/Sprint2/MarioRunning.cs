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
        private float runSpeed;
        private float verticalSpeed;
        public MarioRunning(Mario mario)
        {
            this.mario = mario;
            big = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigRunningSprite(), 1, 3, mario.Location);
            small = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallRunningSprite(), 1, 3, mario.Location);
            fire = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireRunningSprite(), 1, 3,mario.Location);
            runSpeed = 1.5f;
            verticalSpeed = 0;
            //Set Sprite here
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
            
            mario.Location += mario.FacingRight ? new Vector2(runSpeed, verticalSpeed) : new Vector2(-runSpeed, verticalSpeed);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (mario.Fire)
            {
                fire.Draw(spriteBatch, mario.Location, mario.FacingRight);
            }
            else if (mario.Small)
            {
                small.Draw(spriteBatch, mario.Location, mario.FacingRight);
            }
            else
            {
                big.Draw(spriteBatch, mario.Location, mario.FacingRight);
            }
        }
        public void Still()
        {
            mario.State = new MarioStill(mario);
        }
        public void Running()
        {
            //Do Nothing
        }
        public void ChangeDirection()
        {
            mario.State = new MarioChangeDirection(mario);
        }
        public void Jump()
        {
            mario.State = new MarioJump(mario);   
        }
        public void ShootFireball()
        {
            if (mario.Fire)
            mario.State = new MarioShootFireball(mario);
        }
        public void Duck()
        {
            mario.State = new MarioDuck(mario);
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
            else if (mario.Fire)
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