using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class Mario : IPlayer
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
        public IPlayerState state;
        public AnimatedSprite sprite;
        //private MarioSpriteFactory spriteFactory;
        public Mario(int locX, int locY)
        {
            state = new MarioStill(this);
            location = new Vector2(locX, locY);
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

        public Rectangle returnCollisionRectangle()
        {
            return state.returnStateCollisionRectangle();
        }
    }
}
