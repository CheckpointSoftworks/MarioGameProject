using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
     class MarioChangeDirection: IMarioState
    {
        private Mario mario;
        private AnimatedSprite small;
        private AnimatedSprite big;
        private AnimatedSprite fire;

        public MarioChangeDirection(Mario mario)
        {
            this.mario = mario;
            mario.FacingRight = !mario.FacingRight;
            big = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigStillSprite(), 1, 1, mario.Location, 4);
            small = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallStillSprite(), 1, 1, mario.Location, 4);
            fire = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigJumpingSprite(), 1, 1, mario.Location, 4);
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
            mario.State = new MarioRunning(mario);
        }
        public void ChangeDirection()
        {
            
        }
        public void Jump()
        {
            mario.State = new MarioChangeDirection(mario);
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
        public void TakeDamage()
        {

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

