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
        private bool facingRight;
        public bool  FacingRight{
            get 
            {
                return facingRight;
            }
            set
            {
                facingRight = value;
            }
        }        
        private bool small;
        public bool Small
        {
            get
            {
                return small;
            }
            set
            {
                small = value;
            }
        }
        private bool falling;
        public bool Falling
        {
            get
            {
                return falling;
            }
            set
            {
                falling = value;
            }
        }
        private bool fire;
        public bool Fire
        {
            get
            {
                return fire;
            }
            set
            {
                fire = value;
            }
        }
        private bool star;
        public bool Star
        {
            get
            {
                return star;
            }
            set
            {
                star = value;
            }
        }
        private bool isDying;
        public bool IsDying
        {
            get
            {
                return isDying;
            }
            set
            {
                isDying = value;
            }
        }
        private bool isStill;
        public bool IsStill
        {
            get
            {
                return isStill;
            }
            set
            {
                isStill = value;
            }
        }
        private Vector2 location;
        public Vector2 Location
        {
            get
            {
                return location;
            }
        }
        private IPlayerState state;
        public IPlayerState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        public Mario()
        {
            small = true;
            fire = false;
            facingRight = true;
            state = new MarioStill(this);
            location = new Vector2(450, 300);
        }

        public void Update()
        {
            state.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }
    }
}
