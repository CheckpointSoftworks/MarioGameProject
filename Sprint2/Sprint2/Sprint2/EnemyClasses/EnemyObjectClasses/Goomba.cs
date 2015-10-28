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
//        private AnimatedSprite goombaSprite;
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
            location = new Vector2(locX, locY);
            state = new GoombaHealthy(this);
            rigidbody = new AutonomousPhysicsObject();
            directionLeft = false;
            LoadRigidBodyProperties();
        }

        private void LoadRigidBodyProperties()
        {
            rigidbody.AirFriction = 1f;
            rigidbody.GroundFriction = 1f;
            rigidbody.GroundSpeed = 1f;
            rigidbody.MaxFallSpeed = 3f;
            rigidbody.Elasticity = 0.5f;
            rigidbody.IsEnabled = true;
        }

        public void LeftCollision()
        {
            Console.WriteLine("Left");
            directionLeft = true;
            rigidbody.LeftCollision();
        }
        public void RightCollision()
        {
            Console.WriteLine("Right: Velocity is " + rigidbody.Velocity);
            directionLeft = false;
            rigidbody.RightCollision();
        }
        public void TopCollision()
        {
            Console.WriteLine("Top");
            rigidbody.TopCollision();
        }
        public void BottomCollision()
        {
            Console.WriteLine("Bottom");
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
