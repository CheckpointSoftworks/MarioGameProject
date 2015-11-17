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
            sprite = new AnimatedSprite(MarioSpriteFactory.CreateMarioDyingSprite(), UtilityClass.one, UtilityClass.one, mario.Location, UtilityClass.generalTotalFramesAndSpecializedRows);
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
            return MarioState.Die;
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

        public void ShootFireball()
        {
            
        }
        public void Duck()
        {
            
        }

        public void TakeDamage()
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
