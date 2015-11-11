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

        private float transitionDuration;
        private float TransitionToBigTime;
        private float TransitionToFireTime;
        private float TransitionToSmallTime;
        private float TransitionToDifferentDirection;
        private bool transitioning;
        private bool facingRight;
        private bool moveMario;
        private bool canFire;
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
        public MarioState StateStatus()
        {
            return state.State();
        }
        public bool CanFire
        {
            get { return canFire && fire; }
            set { canFire = value && fire; }
        }

        private int timer = UtilityClass.marioStarTimer;
        public ControllablePhysicsObject rigidbody { get; set; }
        public Mario(int locX, int locY)
        {
            small = true;
            fire = false;
            facingRight = true;
            star = false;
            canFire = true;
            transitioning = false;
            location = new Vector2(locX, locY);
            state = new MarioStill(this);
            moveMario = true;
            rigidbody = new ControllablePhysicsObject();
            LoadPhysicsProperties();
            transitionDuration = UtilityClass.marioTransitionDuration;
            TransitionToBigTime = UtilityClass.marioTransitionToBigTime;
            TransitionToFireTime = UtilityClass.marioTransitionToFireTime;
            TransitionToSmallTime = UtilityClass.marioTransitionToSmallTime;
        }

        private void LoadPhysicsProperties()
        {
            rigidbody.Elasticity = UtilityClass.marioElasticity;
            rigidbody.AirFriction = UtilityClass.marioAirFriction;
            rigidbody.GroundFriction = UtilityClass.marioGroundFriction;
            rigidbody.maxVelocityX = UtilityClass.mariomaxVelocityX;
            rigidbody.maxVelocityY = UtilityClass.mariomaxVelocityY;
            rigidbody.GroundSpeed = UtilityClass.marioGroundSpeed;
            rigidbody.JumpSpeed = UtilityClass.marioJumpSpeed;
            rigidbody.JumpDuration = UtilityClass.marioJumpDuration;
            rigidbody.IsEnabled = true;
        }
        public void Update()
        {
            if (Math.Abs(rigidbody.Velocity.Y) > UtilityClass.zero) { state.Jump(); }
            else if (rigidbody.Floored)
            {
                if (Math.Abs(rigidbody.Velocity.X) > UtilityClass.zero)
                {
                    state.Running();
                }
            }
            if ((facingRight && rigidbody.Velocity.X < UtilityClass.zero) || (!facingRight && rigidbody.Velocity.X > UtilityClass.zero))
            {
                facingRight = !facingRight;
                ChangeDirection();
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
                if (timer == UtilityClass.zero)
                {
                    star = false;
                    timer = UtilityClass.marioStarTimer;
                }

                state.Update();

            }
        }

        public void MoveRight()
        {
            if (!state.State().Equals(MarioState.Duck))
            {
                rigidbody.MoveRight();
            }
            else
            {
                facingRight = true;
            }

        }

        public void MoveLeft()
        {
            if (!state.State().Equals(MarioState.Duck)) 
            {
                rigidbody.MoveLeft();
            }
            else
            {
                facingRight = false;
            }
        }

        public void BounceOff()
        {
            rigidbody.ResetJump();
            rigidbody.Jump();
        }

        private void ChangeDirection()
        {
            TransitionToDifferentDirection = UtilityClass.zero;
        }
        public void BecomeBig()
        {
            if (!fire) TransitionToBigTime = UtilityClass.zero;
        }
        public void BecomeFire()
        {
           if (!fire) TransitionToFireTime = UtilityClass.zero;
        }
        public void BecomeSmall()
        {
            TransitionToSmallTime = UtilityClass.zero;
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
                    fire = false;
                    BecomeBig();
                }
                else
                {
                    small = true;
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
                    TransitionToBigTime += UtilityClass.marioTransistionTimerCount;
                    if ((TransitionToBigTime * UtilityClass.ten) % 5 < UtilityClass.one) small = !small;
                    transitioning = (TransitionToBigTime < transitionDuration);
                    if (!transitioning)
                    {
                        fire = false;
                        small = false;
                    }
                }
                if (TransitionToSmallTime < transitionDuration)
                {
                    TransitionToSmallTime += UtilityClass.marioTransistionTimerCount;
                    if ((TransitionToSmallTime * UtilityClass.ten) % 5 < UtilityClass.one) small = !small;
                    transitioning = (TransitionToSmallTime < transitionDuration);
                    if (!transitioning)
                    {
                        fire = false;
                        small = true;
                    }
                }
                if (TransitionToFireTime < transitionDuration)
                {
                    TransitionToFireTime += UtilityClass.marioTransistionTimerCount;

                    if ((TransitionToFireTime * UtilityClass.ten) % 5 < UtilityClass.one)
                    {
                        fire = !fire;
                    }
                    transitioning = (TransitionToFireTime < transitionDuration);
                    if (!transitioning)
                    {
                        small = false;
                        fire = true;
                    }
                }
                if (TransitionToDifferentDirection < transitionDuration)
                {
                    TransitionToDifferentDirection += UtilityClass.marioTransitionDirection;
                    state.ChangeDirection();
                    transitioning = (TransitionToFireTime < transitionDuration);
                }
                if (transitioning&&moveMario)
                {
                    location = new Vector2(location.X, location.Y - UtilityClass.marioTransistionOffset);
                    moveMario = false;
                }
                else if (!transitioning)
                {
                    moveMario = true;
                }
                state.setDrawColor(Color.White);
                state.Draw(spriteBatch, cameraLoc);
            }
            else
            {
                if (timer % 7 == UtilityClass.zero)
                {
                    state.setDrawColor(Color.Purple);
                    state.Draw(spriteBatch, cameraLoc);
                }
                else if (timer % 5 == UtilityClass.zero)
                {
                    state.setDrawColor(Color.Blue);
                    state.Draw(spriteBatch, cameraLoc);
                }
                else if (timer % 4 == UtilityClass.zero)
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
                return new Rectangle(UtilityClass.zero, UtilityClass.zero, UtilityClass.zero, UtilityClass.zero);
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
