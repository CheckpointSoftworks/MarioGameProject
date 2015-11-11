using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class Goomba: IEnemyObject
    {
        private NonPlayerScoreItem score;
        private Vector2 location;
        private bool directionLeft;
        private IEnemyState state;
        public IEnemyState State
        {
            get { return state; }
            set { state = value; }
        }

        private AutonomousPhysicsObject rigidbody;
        public bool DirectionLeft
        {
            get { return directionLeft; }
            set { directionLeft = value; }
        }
        public Goomba(int locX, int locY)
        {
            score = new NonPlayerScoreItem(100, true);
            location = new Vector2(locX, locY);
            state = new GoombaHealthy(this);
            rigidbody = new AutonomousPhysicsObject();
            LoadRigidBodyProperties();
        }

        private void LoadRigidBodyProperties()
        {
            rigidbody.AirFriction = UtilityClass.goombaAirFriction;
            rigidbody.GroundFriction = UtilityClass.goombaGroundFriction;
            rigidbody.GroundSpeed =UtilityClass.goombaGroundSpeed;
            rigidbody.MaxFallSpeed = UtilityClass.goombaMaxFallSpeed;
            rigidbody.Elasticity = UtilityClass.goombaElasticity;
            rigidbody.IsEnabled = false;
        }
        public NonPlayerScoreItem ScoreData()
        {
            return score;
        }
        public void ZeroScoreValue()
        {
            score.ScoreValue = 0;
        }

        public void LeftCollision()
        {
            rigidbody.LeftCollision();
        }
        public void RightCollision()
        {
            rigidbody.RightCollision();
        }
        public void TopCollision()
        {
            rigidbody.TopCollision();
        }
        public void BottomCollision()
        {
            rigidbody.BottomCollision();
        }
        public AutonomousPhysicsObject GetRigidBody()
        {
            return rigidbody;
        }
        
        public void Update()
        {
            rigidbody.UpdatePhysics();
            location += rigidbody.Velocity;
            state.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            state.Draw(spriteBatch, cameraLoc);
        }

        public Rectangle returnCollisionRectangle()
        {
            return state.returnStateCollisionRectangle();
        }

        public void TakeDamage()
        {
            state.TakeDamage();
            ZeroScoreValue();
        }

        public void updateLocation(Vector2 newLocation)
        {
            this.location = newLocation;
        }

        public Vector2 returnLocation()
        {
           return location;
        }
        public bool canHurtMario()
        {
            return true;
        }
        public bool canHurtOtherEnemies()
        {
            return false;
        }
    }
}
