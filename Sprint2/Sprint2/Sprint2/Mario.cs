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
        public Vector2 location;
        public float velX;
        public float velY;
        public IPlayerState state;
        public AnimatedSprite sprite;
        //private MarioSpriteFactory spriteFactory;
        public Mario()
        {
            state = new MarioStill(this);
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
    }
}
