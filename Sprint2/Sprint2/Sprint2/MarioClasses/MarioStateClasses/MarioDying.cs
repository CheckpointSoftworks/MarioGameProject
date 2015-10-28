using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    class MarioDying: IMarioState
    {
        private AnimatedSprite sprite;
        private Mario mario;
        public MarioDying(Mario mario)
        {
            this.mario = mario;
            mario.IsDying = true;
            sprite = new AnimatedSprite(MarioSpriteFactory.CreateMarioDyingSprite(), 1, 1, mario.Location, 4);
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

        }
        public void Running()
        {
           
        }
        public void ChangeDirection()
        {
            
        }
        public void Jump()
        {
            
        }
        public void JumpRun()
        {
          
        }
        public void ShootFireball()
        {
            
        }
        public void Duck()
        {
            
        }
        public void DuckRun()
        {
            
        }
        public void Dying()
        {
            
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
