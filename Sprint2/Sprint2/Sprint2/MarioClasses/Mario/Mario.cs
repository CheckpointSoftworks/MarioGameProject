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

        private float transitionDuration = 3f;
        public float TransitionToBigTime = 10;
        public float TransitionToFireTime = 10;
        public float TransitionToSmallTime = 10;
        private bool transitioning;
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
        private IMarioState previousState;
        private IMarioState transitionState;
        public IMarioState TransitionToState
        {
            set { transitionState = value; }
        }
        private int timer = 600;
        public ControllablePhysicsObject rigidbody;
        public Mario(int locX, int locY)
        {
            small = true;
            fire = false;
            facingRight = true;
            star = false;
            isDying = false;
            transitioning = false;
            location = new Vector2(locX, locY);
            state = new MarioStill(this);
            rigidbody = new ControllablePhysicsObject();
            LoadPhysicsProperties();
        }

        private void LoadPhysicsProperties()
        {
            rigidbody.Elasticity = 0f;
            rigidbody.AirFriction = 1f;
            rigidbody.GroundFriction = 0.7f;
            rigidbody.maxVelocityX = 20;
            rigidbody.maxVelocityY = 10;
            rigidbody.GroundSpeed = 10;
            rigidbody.JumpSpeed = -65;
            rigidbody.JumpDuration = 1;
            rigidbody.IsEnabled = true;
        }
        public void Update()
        {
            if (Math.Abs(rigidbody.Velocity.Y) > 0) { state.Jump(); }
            else if (rigidbody.Floored)
            {
                if (Math.Abs(rigidbody.Velocity.X) > 0)
                {
                    state.Running();
                }
                else
                {
                    state.Still();
                }
            }
            if (!transitioning)
            {
                rigidbody.UpdatePhysics();
                location += rigidbody.Velocity;
            }
            
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
        public void BecomeBig()
        {
            TransitionToBigTime = 0;
        }
        public void BecomeFire()
        {
            TransitionToFireTime = 0;
        }
        public void BecomeSmall()
        {
            TransitionToSmallTime = 0;
        }
        public void TakeDamage()
        {
            if (small & !star)
            {
                state = new MarioDying(this);
            }
            else
            {
                if (fire)
                {
                    BecomeBig();
                }
                else
                {
                    BecomeSmall();
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            if (!star)
            {
                if (TransitionToBigTime < transitionDuration)
                {
                   // Console.WriteLine("Big!");
                    TransitionToBigTime += 0.1f;
                    if ((TransitionToBigTime * 10) % 5 < 1) small = !small;
                    transitioning = (TransitionToBigTime < transitionDuration);
                    if (!transitioning) 
                    {
                        //Console.WriteLine("Not big!");
                        fire = false;
                        small = false;
                    }
                }
                if (TransitionToSmallTime < transitionDuration)
                {
                    //Console.WriteLine("Small!");
                    TransitionToSmallTime += 0.1f;
                    if ((TransitionToSmallTime * 10) % 5 < 1) small = !small;
                    transitioning = (TransitionToSmallTime < transitionDuration);
                    if (!transitioning)
                    {
                        //Console.WriteLine("Not small!");
                        fire = false;
                        small = true;
                    }
                }
                if (TransitionToFireTime < transitionDuration)
                {
                    TransitionToFireTime += 0.1f;
                    //Console.WriteLine("Transition time: " + (TransitionToFireTime*10)%3);
                    if ((TransitionToFireTime * 10) % 5 < 1) { 
                        //Console.WriteLine("SWitch");
                        fire = !fire; 
                    }
                    transitioning = (TransitionToFireTime < transitionDuration);
                    if (!transitioning)
                    {
                        small = false;
                        fire = true;
                    }
                }
                state.setDrawColor(Color.White);
                state.Draw(spriteBatch, cameraLoc);
            }
            else
            {
                if (timer % 7 == 0)
                {
                    state.setDrawColor(Color.Purple);
                    state.Draw(spriteBatch, cameraLoc);
                }
                else if (timer % 5 == 0)
                {
                    state.setDrawColor(Color.Blue);
                    state.Draw(spriteBatch, cameraLoc);
                }
                else if (timer % 4 == 0)
                {
                    state.setDrawColor(Color.Red);
                    state.Draw(spriteBatch, cameraLoc);
                }
                else
                {
                    state.setDrawColor(Color.Gold);
                    state.Draw(spriteBatch, cameraLoc);
                }
            }
        }


        public Rectangle returnCollisionRectangle()
        {
            if (transitioning)
            {
                return new Rectangle(0, 0, 0, 0);
            }
            else
            {
                return state.returnStateCollisionRectangle();
            }
        }
        public Vector2 returnLocation()
        {
            return location;
        }
    }
}
