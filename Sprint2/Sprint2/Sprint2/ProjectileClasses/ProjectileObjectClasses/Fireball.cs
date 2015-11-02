using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class Fireball: IProjectile
    {

        private ISprite sprite;

        private Rectangle collisionRectangle;
        private bool testForCollision;
        private Vector2 location;
        private AutonomousPhysicsObject rigidbody;
        private bool facingRight;
        private int timer;

        public Fireball(int x, int y, bool facingRight)
        {
            location = new Vector2(x, y);
            sprite = new FireballSprite(location);
            collisionRectangle = sprite.returnCollisionRectangle();
            testForCollision = true;
            timer = 200;
            rigidbody = new AutonomousPhysicsObject();
            this.facingRight = facingRight;
            LoadRigidBodyProperties();
        }
        private void LoadRigidBodyProperties()
        {
            rigidbody.AirFriction = 0.8f;
            rigidbody.GroundFriction = 1f;
            rigidbody.MaxFallSpeed = 1.5f;
            rigidbody.Elasticity = 1f;
            if (facingRight) { rigidbody.GroundSpeed = 1.5f; }
            else{ rigidbody.GroundSpeed = -1.5f; }
            rigidbody.IsEnabled = true;
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
        public void Update()
        {
            if (testForCollision&&timer>0)
            {
                rigidbody.UpdatePhysics();
                location += rigidbody.Velocity;
                ((FireballSprite)(sprite)).Update(location);
                timer--;
            }
            else
            {
                sprite = new UsedItemSprite(location);
                testForCollision = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            sprite.Draw(spriteBatch, cameraLoc);
        }

        public Vector2 returnLocation()
        {
            return location;
        }

        public Rectangle returnCollisionRectangle()
        {
            return sprite.returnCollisionRectangle();
        }

        public bool checkForCollisionTestFlag()
        {
            return testForCollision;
        }
        public void updateLocation(Vector2 location)
        {
            this.location = location;
            ((FireballSprite)(sprite)).Update(location);
        }
        public AutonomousPhysicsObject RigidBody()
        {
            return rigidbody;
        }

        public bool DoneFireBall()
        {
            bool complete = false;
            if (timer == 0)
            {
                complete = true;
            }
            return complete;
        }
    }
}
