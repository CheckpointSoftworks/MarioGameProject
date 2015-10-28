using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class Koopa: IEnemyObject
    {
        private Vector2 location;
        private bool directionLeft;
        private AutonomousPhysicsObject rigidbody;
        private IEnemyState state;
        public IEnemyState State
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
        public bool DirectionLeft
        {
            get { return directionLeft; }
            set { directionLeft = value; }
        }

        public Koopa(int locX, int locY)
        {
            location = new Vector2(locX, locY);
            state = new KoopaHealthy(this);
            rigidbody = new AutonomousPhysicsObject();
            LoadRigidBodyProperties();
            directionLeft = false;
        }

        private void LoadRigidBodyProperties()
        {
            rigidbody.AirFriction = 1f;
            rigidbody.GroundFriction = 1f;
            rigidbody.GroundSpeed = -1f;
            rigidbody.MaxFallSpeed = 3f;
            rigidbody.Elasticity = 0f;
            rigidbody.IsEnabled = true;
        }

        public void LeftCollision()
        {
            directionLeft = true;
            rigidbody.LeftCollision();
        }
        public void RightCollision()
        {
            directionLeft = false;
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

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

        public Rectangle returnCollisionRectangle()
        {
            return state.returnStateCollisionRectangle();
        }

        public void TakeDamage()
        {
            state.TakeDamage();
        }

        public void updateLocation(Vector2 newLocation)
        {
            this.location = newLocation;
        }

        public Vector2 returnLocation()
        {
            return location;
        }
    }
}
