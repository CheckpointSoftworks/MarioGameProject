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


        private bool facingRight;
        public bool FacingRight
        {
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
            set
            {
                location = value;
            }
        }
        private IMarioState state;
        public IMarioState State
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
        private int timer = 600;
        public Mario(int locX, int locY)
        {
            small = true;
            fire = false;
            facingRight = true;
            star = false;
            isDying = false;
            location = new Vector2(locX, locY);
            state = new MarioStill(this);
        }

        public void Update()
        {
            if (!star)
            {
                state.Update();
            }
            else
            {
                timer--;
                if (timer == 0)
                {
                    star = false;
                }

                state.Update();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!star)
            {
                state.setDrawColor(Color.White);
                state.Draw(spriteBatch);
            }
            else
            {
                if (timer % 7 == 0)
                {
                    state.setDrawColor(Color.Purple);
                    state.Draw(spriteBatch);
                }
                else if (timer % 5 == 0)
                {
                    state.setDrawColor(Color.Blue);
                    state.Draw(spriteBatch);
                }
                else if (timer % 4 == 0)
                {
                    state.setDrawColor(Color.Red);
                    state.Draw(spriteBatch);
                }
                else
                {
                    state.setDrawColor(Color.Gold);
                    state.Draw(spriteBatch);
                }
            }
        }

        public Rectangle returnCollisionRectangle()
        {
            return state.returnStateCollisionRectangle();
        }
    }
}
