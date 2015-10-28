using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    class MarioRunning: IMarioState
    {
        private Mario mario;
        AnimatedSprite small;
        AnimatedSprite big;
        AnimatedSprite fire;
        public MarioRunning(Mario mario)
        {
            this.mario = mario;
            big = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigRunningSprite(), 1, 3, mario.Location, 4);
            small = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallRunningSprite(), 1, 3, mario.Location, 4);
            fire = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireRunningSprite(), 1, 3,mario.Location, 4);
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
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            if (mario.Fire)
            {
                fire.Draw(spriteBatch, mario.Location, cameraLoc, mario.FacingRight);
            }
            else if (mario.Small)
            {
                small.Draw(spriteBatch, mario.Location, cameraLoc, mario.FacingRight);
            }
            else
            {
                big.Draw(spriteBatch, mario.Location, cameraLoc, mario.FacingRight);
            }
        }
        public void Still()
        {
            mario.State = new MarioStill(mario);
        }
        public void Running()
        {
            
        }
        public void ChangeDirection()
        {
            mario.State = new MarioChangeDirection(mario);
        }
        public void Jump()
        {
            mario.State = new MarioJumpRun(mario);   
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
            mario.State = new MarioDuckRun(mario);
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