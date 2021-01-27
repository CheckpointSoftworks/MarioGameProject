using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{  
    class MarioShootFireball: IMarioState
    {
        private Mario mario;
        private AnimatedSprite sprite;
        public MarioShootFireball(Mario mario)
        {
            this.mario = mario;
            mario.actions.ShotFired();
            sprite = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireStillShootSprite(), UtilityClass.one, UtilityClass.one, mario.Location, UtilityClass.generalTotalFramesAndSpecializedRows);
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
            return MarioState.Shoot;
        }
        public void Still()
        {
            
        }
        public void Running()
        {
            //mario.State = new MarioRunning(mario);
        }
        public void ChangeDirection()
        {
            mario.State = new MarioChangeDirection(mario);
        }
        public void Jump()
        {
            mario.State = new MarioChangeDirection(mario);
        }
        public void ShootFireball()
        {
            
        }
        public void ShootIceball() 
        {

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
            Rectangle collisionRectangle = new Rectangle(UtilityClass.zero, UtilityClass.zero, UtilityClass.zero, UtilityClass.zero);

            

            return collisionRectangle;
        }
        public void setDrawColor(Color color)
        {
            
        }
    }
}
