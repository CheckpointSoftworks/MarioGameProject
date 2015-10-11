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
            sprite = new AnimatedSprite(MarioSpriteFactory.CreateMarioDyingSprite(), 1, 1, mario.Location);
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
           // mario.State = new MarioRunning(mario);
        }
        public void ChangeDirection()
        {
            //Nothing yet
        }
        public void Jump()
        {
            //mario.State = new MarioJump(mario);
        }
        public void JumpRun()
        {
           // mario.State = new MarioJumpRun(mario);
        }
        public void ShootFireball()
        {
            //Nothing yet
        }
        public void Duck()
        {
            //mario.State = new MarioDuck(mario);
        }
        public void DuckRun()
        {
            //mario.State = new MarioDuckRun(mario);
        }
        public void Dying()
        {
            //Nothing
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
