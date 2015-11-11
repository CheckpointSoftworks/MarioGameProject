using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    class MarioDuck: IMarioState
    {
        private AnimatedSprite sprite;
        private Mario mario;
        
        public MarioDuck(Mario mario)
        {
            this.mario = mario;
            if (mario.Fire)
            {
                sprite = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireDuckSprite(), UtilityClass.one, UtilityClass.one,mario.Location, UtilityClass.four);
            }
            else if (mario.Small)
            {
                sprite = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallStillSprite(), UtilityClass.one, UtilityClass.one, mario.Location, UtilityClass.four);
            }
            else
            {
                sprite = new AnimatedSprite(MarioSpriteFactory.CreateMarioDuckSprite(), UtilityClass.one, UtilityClass.one,mario.Location, UtilityClass.four);
            }
        }
        public void Update()
        {
            sprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            sprite.Draw(spriteBatch, mario.Location, cameraLoc, mario.FacingRight);
        }
        public MarioState State()
        {
            return MarioState.Duck;
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
            mario.State = new MarioStill(mario);
        }

        public void ShootFireball()
        {
            if (mario.Fire)
                mario.State = new MarioShootFireball(mario);
        }
        public void Duck()
        {
            
        }
        public void TakeDamage()
        {

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
