﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class MarioStill: IMarioState
    {
        private Mario mario;
        AnimatedSprite big;
        AnimatedSprite small;
        AnimatedSprite fire;
        public MarioStill(Mario mario)
        {
            this.mario = mario;
            //Set Sprite here
            big = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigStillSprite(), 1, 1, mario.Location);
            small = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallStillSprite(), 1, 1, mario.Location);
            fire = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireStillSprite(), 1, 1, mario.Location);
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
            if (mario.Small)
            {
                small.Draw(spriteBatch, mario.Location, mario.FacingRight);
            }
            else if (mario.Fire)
            {
                fire.Draw(spriteBatch, mario.Location, mario.FacingRight);
            }
            else
            {
                big.Draw(spriteBatch, mario.Location, mario.FacingRight);
            }
        }
        public void Still()
        {
            //Do nothing
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
            mario.State = new MarioJump(mario);
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
            mario.State = new MarioDuck(mario);
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