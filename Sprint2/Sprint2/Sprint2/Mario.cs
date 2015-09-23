using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class Mario : IGameObject
    {
        public bool facingRight;
        public bool small;
        public bool falling;
        public bool fire;
        public bool star;
        public bool isChangingDirection { get; set; }
        public bool isDucking { get; set; }
        public bool isDying { get; set; }
        public bool isJumping { get; set; }
        public bool isRunning { get; set; }
        public bool isShooting { get; set; }
        public bool isStill { get; set; }
        public Vector2 location;
        public float velX;
        public float velY;
        //public Vector2 location;
        public IPlayerState state;
        public AnimatedSprite sprite;
        //private MarioSpriteFactory spriteFactory;
        public Mario()
        {
            small = true;
            facingRight = true;
            falling = false;
            star = false;
            star = false;
            isChangingDirection = false;
            isDucking = false;
            isJumping = false;
            isRunning = false;
            isShooting = false;
            isStill = true;
            state = new MarioStill(this);
            location = new Vector2(30, 200);
        }

        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

        void Still()
        {
            state.Still();
        }
        void Running()
        {
            state.Running();
        }
        void ChangeDirection()
        {
            state.ChangeDirection();
        }
        void Jump()
        {
            state.Jump();
        }
        void ShootFireball()
        {
            state.ShootFireball();
        }
        void Duck()
        {
            state.Duck();
        }
        void Dying()
        {
            state.Dying();
        }

        /*void Draw(spriteBatch spriteBatch)
         * {
         *  if (!facingRight)
         *  {
         *      sprite = flipped sprite   
         *  }
         *  Draw(sprite, location) 
         * 
         * 
         * */
    }
}
