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
        private PlayerScoreItem lives;
        private PlayerScoreItem points;
        private PlayerScoreItem coins;
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

        private int timer = 600;
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
            transitionDuration = 3f;
            TransitionToBigTime = 10;
            TransitionToFireTime = 10;
            TransitionToSmallTime = 10;
            lives = new PlayerScoreItem(PlayerScoreItem.GUIType.mario, 3,new Vector2(400,240),false);
            points = new PlayerScoreItem("MARIO\n", 0, new Vector2(5, 1),true);
            coins = new PlayerScoreItem(PlayerScoreItem.GUIType.coin, 0, new Vector2(100, 0),true);
        }

        private void LoadPhysicsProperties()
        {
            rigidbody.Elasticity = 0.0f;
            rigidbody.AirFriction = 0.95f;
            rigidbody.GroundFriction = 0.7f;
            rigidbody.maxVelocityX = 12.0f;
            rigidbody.maxVelocityY = 6.0f;
            rigidbody.GroundSpeed = 6.0f;
            rigidbody.JumpSpeed = -48.0f;
            rigidbody.JumpDuration = 1.6f;
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
            }
            if ((facingRight && rigidbody.Velocity.X < 0) || (!facingRight && rigidbody.Velocity.X > 0))
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
                if (rigidbody.Floored) points.ResetChain();

            }
            else
            {
                timer--;
                if (timer == 0)
                {
                    star = false;
                    timer = 600;
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
        /// <summary>
        /// Special case jump that can only be called by enemies or bouncy objects
        /// </summary>
        public void BounceOff()
        {
            rigidbody.ResetJump();
            rigidbody.Jump();
        }
        public PlayerScoreItem GetPoints()
        {
            return points;
        }
        public PlayerScoreItem GetLives()
        {
            return lives;
        }
        public PlayerScoreItem GetCoins()
        {
            return coins;
        }
        public String PointsToString()
        {
            return points.ToString();
        }
        public float CurrentGroundSpeed()
        {
            return rigidbody.Velocity.X;
        }

        public void ScoreEvent(NonPlayerScoreItem target)
        {
            points.UpdateScore(target.ScoreValue);
            if (target.Chainable)
            {
                if (points.ComboValue() < 10) points.ChainHit();
                else lives.UpdateScore(1);
            }
        }
        public void AddCoin()
        {
            coins.UpdateScore(1);
            if (coins.ScoreValue == 100)
            {
                coins.ScoreValue = 0;
                lives.UpdateScore(1);
            }
        }

        public void OneUp()
        {
            lives.UpdateScore(1);
        }

        public void ProjectileScoreEvent(NonPlayerScoreItem target)
        {
            points.UpdateScoreNoChain(target.ScoreValue);
        }

        private void ChangeDirection()
        {
            TransitionToDifferentDirection = 0;
        }
        public void BecomeBig()
        {
            if (!fire) TransitionToBigTime = 0;
        }
        public void BecomeFire()
        {
           if (!fire) TransitionToFireTime = 0;
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
                lives.UpdateScore(-1);
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
            points.ResetChain();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            if (!star)
            {
                if (TransitionToBigTime < transitionDuration)
                {
                    TransitionToBigTime += 0.1f;
                    if ((TransitionToBigTime * 10) % 5 < 1) small = !small;
                    transitioning = (TransitionToBigTime < transitionDuration);
                    if (!transitioning)
                    {
                        fire = false;
                        small = false;
                    }
                }
                if (TransitionToSmallTime < transitionDuration)
                {
                    TransitionToSmallTime += 0.1f;
                    if ((TransitionToSmallTime * 10) % 5 < 1) small = !small;
                    transitioning = (TransitionToSmallTime < transitionDuration);
                    if (!transitioning)
                    {
                        fire = false;
                        small = true;
                    }
                }
                if (TransitionToFireTime < transitionDuration)
                {
                    TransitionToFireTime += 0.1f;

                    if ((TransitionToFireTime * 10) % 5 < 1)
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
                    TransitionToDifferentDirection += 0.4f;
                    state.ChangeDirection();
                    transitioning = (TransitionToFireTime < transitionDuration);
                }
                if (transitioning&&moveMario)
                {
                    location = new Vector2(location.X, location.Y - 16);
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
