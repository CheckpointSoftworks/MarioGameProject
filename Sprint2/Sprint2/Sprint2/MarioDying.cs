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
            sprite = new AnimatedSprite(MarioSpriteFactory.CreateMarioDuckSprite(false), 1, 1,mario.location);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
        public void Still()
        {
            //Nothing, death consumes all
        }
        public void Running()
        {
            //Nothing, death consumes all
        }
        public void ChangeDirection()
        {
            //Nothing, death consumes all
        }
        public void Jump()
        {
            //Nothing, death consumes all
        }
        public void ShootFireball()
        {
            //Nothing, death consumes all
        }
        public void Duck()
        {
            //Nothing, death consumes all
        }
        public void Dying()
        {
            //Nothing, death consumes all
        }
    }
}
