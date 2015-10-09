using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    class MarioDuck: IPlayerState
    {
        private AnimatedSprite sprite;
        private Mario mario;
        public MarioDuck(Mario mario)
        {
            this.mario = mario;
            if (mario.Fire)
            {
                sprite = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireDuckSprite(), 1, 1,mario.Location);
            }
            else
            {
                sprite = new AnimatedSprite(MarioSpriteFactory.CreateMarioDuckSprite(), 1, 1,mario.Location);
            }//Set Sprite here
        }
        public void Update()
        {
            sprite.Update();
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
            //Do nothing, maybe stand up?
        }
        public void ChangeDirection()
        {
            //Do nothing, invalid
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
            // Nothing
        }
        public void Dying()
        {
            mario.State = new MarioDying(mario);
        }
        public Rectangle returnStateCollisionRectangle()
        {
            return sprite.returnCollisionRectangle();
        }
    }
}
