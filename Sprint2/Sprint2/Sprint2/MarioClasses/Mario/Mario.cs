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
        public PlayerScoreItem[] Scores
        {
            get
            {
                stats.PrintAll();
                actions.PrintAll();
                return new PlayerScoreItem[] { coins, lives, points };
            }
            set
            {
                coins = value[0];
                lives = value[1];
                points = value[2];
            }
        }

        public PlayerStatManager stats { get; set; }
        public PlayerActionStatManager actions { get; set; }
        public int takingDamage { get; set; }

        private float transitionDuration;
        private float TransitionToBigTime;
        private float TransitionToFireTime;
        private float TransitionToIceTime;
        private float TransitionToSmallTime;
        private float TransitionToDifferentDirection;
        private bool transitioning;
        private bool moveMario;
        private bool canFire;
        private bool canIce;
        public bool FacingRight { get; set; }
        public bool Small { get; set; }
        public bool Fire { get; set; }
        public bool Ice { get; set; }
        public bool Star { get; set; }
        public Vector2 Location { get; set; }
        public IMarioState State { get; set; }
        public MarioState StateStatus()
        {
            return State.State();
        }
        public bool CanFire
        {
            get { return canFire && Fire; }
            set { canFire = value && Fire; }
        }
        public bool CanIce
        {
            get { return canIce && Ice; }
            set { canIce = value && Ice; }
        }

        private int timer = UtilityClass.marioStarTimer;
        public ControllablePhysicsObject rigidbody { get; set; }
        public Mario(int locX, int locY)
        {
            Small = true;
            Fire = false;
            Ice = false;
            FacingRight = true;
            Star = false;
            canFire = true;
            canIce = true;
            transitioning = false;
            Location = new Vector2(locX, locY);
            State = new MarioStill(this);
            moveMario = true;
            rigidbody = new ControllablePhysicsObject();
            takingDamage = 0;
            LoadPhysicsProperties();
            lives = new PlayerScoreItem(PlayerScoreItem.GUIType.mario, UtilityClass.StartingLives, UtilityClass.GUIMarioPosition, false);
            points = new PlayerScoreItem(UtilityClass.GUIMarioScoreName, UtilityClass.zero, UtilityClass.GUIMarioScorePosition, true);
            coins = new PlayerScoreItem(PlayerScoreItem.GUIType.coin, UtilityClass.zero, UtilityClass.GUIMarioCoinsPosition, true);
            transitionDuration = UtilityClass.marioTransitionDuration;
            TransitionToBigTime = UtilityClass.marioTransitionToBigTime;
            TransitionToFireTime = UtilityClass.marioTransitionToFireTime;
            TransitionToIceTime = UtilityClass.marioTransitionToIceTime;
            TransitionToSmallTime = UtilityClass.marioTransitionToSmallTime;
            stats = new PlayerStatManager();
            actions = new PlayerActionStatManager();
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
        public void Update(GameTime time)
        {
            RegisterConditionTime(time);
            if (Math.Abs(rigidbody.Velocity.Y) > UtilityClass.zero) { State.Jump(); }
            else if (rigidbody.Floored)
            {
                points.ResetChain();
                if (Math.Abs(rigidbody.Velocity.X) > UtilityClass.marioMinMovementSpeed)
                {
                    State.Running();
                }
                else if (!StateStatus().Equals(MarioState.Duck))
                {
                    State.Still();
                }
            }
            if ((FacingRight && rigidbody.Velocity.X < UtilityClass.zero) || (!FacingRight && rigidbody.Velocity.X > UtilityClass.zero))
            {
                FacingRight = !FacingRight;
                ChangeDirection();
            }
            if (!transitioning)
            {
                rigidbody.UpdatePhysics();
                Location += rigidbody.Velocity;
            }

            if (!Star)
            {
                State.Update();
            }
            else
            {
                if (timer == UtilityClass.marioStarTimer)
                {
                    MusicFactory.StarMan();
                }
                if (timer == UtilityClass.zero)
                {
                    Star = false;
                    timer = UtilityClass.marioStarTimer;
                    MusicFactory.MainTheme();
                }
                timer--;

                State.Update();

            }
        }

        private void RegisterConditionTime(GameTime time)
        {
            if (Star) { actions.AddStarTime(time.ElapsedGameTime.Milliseconds); }
            if (Fire) { actions.AddFireTime(time.ElapsedGameTime.Milliseconds); }
            //if (Ice) { actions.AddIceTime(time.ElapsedGameTime.Milliseconds); }
            else if (!Small) { actions.AddBigTime(time.ElapsedGameTime.Milliseconds); }
            if (Math.Abs(rigidbody.Velocity.Y)>0.1) { actions.AddAirTime(time.ElapsedGameTime.Milliseconds); }
        }

        public void MoveRight()
        {
            if (!State.State().Equals(MarioState.Duck))
            {
                rigidbody.MoveRight();
            }
            else { FacingRight = true; }
        }

        public void LoseLife()
        {
            lives.UpdateScoreNoChain(-1);
        }

        public void MoveLeft()
        {
            if (!State.State().Equals(MarioState.Duck)) 
            {
                rigidbody.MoveLeft();
            }
            else
            {
                FacingRight = false;
            }
        }

        public void Jump()
        {
            if (rigidbody.Floored && rigidbody.Velocity.Y < 0)
            {
                if (Small) SoundEffectFactory.JumpSmall();
                else SoundEffectFactory.JumpBig();
                actions.AddJump();
            }
            State.Jump();
            rigidbody.Jump();
        }

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

        public void DieImmediately()
        {
            State.Dying();
        }

        public void ScoreEvent(NonPlayerScoreItem target)
        {
            points.UpdateScore(target.ScoreValue);
            if (target.Chainable)
            {
                if (points.ComboValue() < UtilityClass.ten) points.ChainHit();
                else lives.UpdateScore(UtilityClass.one);
            }
        }
        public void AddCoin()
        {
            coins.UpdateScoreNoChain(UtilityClass.one);
            if (coins.ScoreValue == UtilityClass.addCoinScore)
            {
                coins.ScoreValue = UtilityClass.zero;
                lives.UpdateScoreNoChain(UtilityClass.one);
            }
            points.UpdateScoreNoChain(UtilityClass.CoinScoreValue);
            stats.GotCoin();
        }

        public void OneUp()
        {
            lives.UpdateScore(UtilityClass.one);
        }

        public void ProjectileScoreEvent(NonPlayerScoreItem target)
        {
            points.UpdateScoreNoChain(target.ScoreValue);
        }

        private void ChangeDirection()
        {
            TransitionToDifferentDirection = UtilityClass.zero;
        }
        public void BecomeBig()
        {
            if (!Fire && !Ice)
            {
                TransitionToBigTime = UtilityClass.zero;
            }
        }
        public void BecomeFire()
        {
           if (!Fire) TransitionToFireTime = UtilityClass.zero;
        }
        public void BecomeIce()
        {
            if (!Ice) TransitionToIceTime = UtilityClass.zero;
        }
        public void BecomeSmall()
        {
            TransitionToSmallTime = UtilityClass.zero;
        }
        public void TakeDamage()
        {
            if (Small & !Star)
            {
                State.Dying();
            }
            else if (!Star)
            {
                takingDamage++;
                SoundEffectFactory.TransitionSmall();
                if (Fire)
                {
                    Fire = false;
                    BecomeBig();
                }
                else if (Ice)
                {
                    Ice = false;
                    BecomeBig();
                }
                else
                {
                    Small = true;
                    BecomeSmall();
                }
                actions.ReceivedDamage();
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            
                if (TransitionToBigTime < transitionDuration)
                {
                    TransitionToBigTime += UtilityClass.marioTransistionTimerCount;
                    if ((TransitionToBigTime * UtilityClass.ten) % UtilityClass.marioTranstitionTimeModulus < UtilityClass.one) Small = !Small;
                    transitioning = (TransitionToBigTime < transitionDuration);
                    if (!transitioning)
                    {
                        Fire = false;
                        Ice = false;
                        Small = false;
                    }
                }
                if (TransitionToSmallTime < transitionDuration)
                {
                    TransitionToSmallTime += UtilityClass.marioTransistionTimerCount;
                    if ((TransitionToSmallTime * UtilityClass.ten) % UtilityClass.marioTranstitionTimeModulus < UtilityClass.one) Small = !Small;
                    transitioning = (TransitionToSmallTime < transitionDuration);
                    if (!transitioning)
                    {
                        Fire = false;
                        Ice = false;
                        Small = true;
                    }
                }
                if (TransitionToFireTime < transitionDuration)
                {
                    TransitionToFireTime += UtilityClass.marioTransistionTimerCount;

                    if ((TransitionToFireTime * UtilityClass.ten) % UtilityClass.marioTranstitionTimeModulus < UtilityClass.one)
                    {
                        if (Ice) { Ice = false; Fire = !Fire; }
                        else Fire = !Fire;
                    }
                    transitioning = (TransitionToFireTime < transitionDuration);
                    if (!transitioning)
                    {
                        Small = false;
                        Fire = true;
                        Ice = false;
                    }
                }
                else if (TransitionToIceTime < transitionDuration)
                {
                    TransitionToIceTime += UtilityClass.marioTransistionTimerCount;

                    if ((TransitionToIceTime * UtilityClass.ten) % UtilityClass.marioTranstitionTimeModulus < UtilityClass.one)
                    {
                        if (Fire) { Fire = false; Ice = !Ice; }
                        else Ice = !Ice;
                    }
                    transitioning = (TransitionToIceTime < transitionDuration);
                    if (!transitioning)
                    {
                        Small = false;
                        Ice = true;
                        Fire = false;
                    }
                }
                if (TransitionToDifferentDirection < transitionDuration)
                {
                    TransitionToDifferentDirection += UtilityClass.marioTransitionDirection;
                    State.ChangeDirection();
                    transitioning = ((TransitionToFireTime < transitionDuration) || (TransitionToIceTime < transitionDuration));
                }
                if (transitioning&&moveMario)
                {
                    Location = new Vector2(Location.X, Location.Y - UtilityClass.marioTransistionOffset);
                    moveMario = false;
                }
                else if (!transitioning)
                {
                    moveMario = true;
                }
                State.setDrawColor(Color.White);
                State.Draw(spriteBatch, cameraLoc);
            
            if (Star)
            {
                if (timer % UtilityClass.marioStarColorOne == UtilityClass.zero)
                {
                    State.setDrawColor(Color.Purple);
                    State.Draw(spriteBatch, cameraLoc);
                }
                else if (timer % UtilityClass.marioStarColorTwo == UtilityClass.zero)
                {
                    State.setDrawColor(Color.Blue);
                    State.Draw(spriteBatch, cameraLoc);
                }
                else if (timer % UtilityClass.marioStarColorThree == UtilityClass.zero)
                {
                    State.setDrawColor(Color.Red);
                    State.Draw(spriteBatch, cameraLoc);
                }
                else
                {
                    State.setDrawColor(Color.Gold);
                    State.Draw(spriteBatch, cameraLoc);
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
                return State.returnStateCollisionRectangle();
            }
        }

        public Vector2 GetLocation()
        {
            return Location;
        }
    }
}
