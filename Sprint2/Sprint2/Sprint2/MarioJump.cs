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
        private float jumpSpeed;
        private float runSpeed;
        public MarioJump(Mario mario)
        {
            this.mario = mario;
            big = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigJumpingSprite(), 1, 1, mario.Location);
            small = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallJumpingSprite(), 1, 1, mario.Location);
            fire = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireJumpingSprite(), 1, 1, mario.Location);
            jumpSpeed = 1.5f;
            runSpeed = 0;            
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
            mario.Location -= new Vector2(runSpeed, jumpSpeed);
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
            mario.State = new MarioJumpRun(mario);
        }
        public void ChangeDirection()
        {
            mario.State = new MarioChangeDirection(mario);
        }
        public void Jump()
        {
            //Do Nothing
        }
        public void JumpRun()
        {
            mario.State = new MarioJumpRun(mario);
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
        public void DuckRun()
        {
            mario.State = new MarioDuckRun(mario);
        }
        public void Dying()
        {
            if (!mario.Star)
            {
                mario.State = new MarioDying(mario);
            }
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

        public void setDrawColor(Color color)
        {
            if (mario.Small)
            {
                small.setColorForDrawing(color);
            }
            else if (mario.Fire)
            {
                fire.setColorForDrawing(color);
            }
            else
            {
                big.setColorForDrawing(color);
            }
        }
    }
}
