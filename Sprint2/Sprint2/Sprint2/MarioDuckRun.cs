using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    class MarioDuckRun : IMarioState
    {
        private AnimatedSprite sprite;
        private Mario mario;
        private float duckSpeed;
        private float runSpeed;
        public MarioDuckRun(Mario mario)
        {
            this.mario = mario;
            if (mario.Fire)
            {
                sprite = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireDuckSprite(), 1, 1, mario.Location);
            }
            else if (mario.Small)
            {
                sprite = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallStillSprite(), 1, 1, mario.Location);
            }
            else
            {
                sprite = new AnimatedSprite(MarioSpriteFactory.CreateMarioDuckSprite(), 1, 1, mario.Location);
            }
            duckSpeed = 1.5f;
            runSpeed = mario.FacingRight ? 1.5f : -1.5f;
        }
        public void Update()
        {
            sprite.Update();
            mario.Location += new Vector2(runSpeed, duckSpeed);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, mario.Location, mario.FacingRight);
        }
        public void Still()
        {
            mario.State = new MarioStill(mario);
        }
        public void Running()
        {
            //Nothing
        }
        public void ChangeDirection()
        {
            //Do nothing, invalid
        }
        public void Jump()
        {
            mario.State = new MarioStill(mario);
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
            // Nothing
        }
        public void DuckRun()
        {
            //Nothing
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
            return sprite.returnCollisionRectangle();
        }

        public void setDrawColor(Color color)
        {
            sprite.setColorForDrawing(color);
        }

    }
}
