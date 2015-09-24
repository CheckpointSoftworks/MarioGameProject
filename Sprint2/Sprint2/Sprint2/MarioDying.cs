using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    class MarioDying: IPlayerState
    {
        private AnimatedSprite sprite;
        private Mario mario;
        public MarioDying(Mario mario)
        {
            this.mario = mario;
            sprite = new AnimatedSprite(MarioSpriteFactory.CreateMarioDyingSprite(), 1, 1);
        }
        public void Update()
        {
            sprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, mario.location, mario.facingRight);
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
            //Nothing yet
        }
        public void Jump()
        {
            mario.state = new MarioJump(mario);
        }
        public void ShootFireball()
        {
            //Nothing yet
        }
        public void Duck()
        {
            mario.state = new MarioDuck(mario);
        }
        public void Dying()
        {
            //Nothing
        }
    }
}
