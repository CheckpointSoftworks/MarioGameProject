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
        private bool testForCollision;
        private Vector2 location;
        private AutonomousPhysicsObject rigidbody;
        private bool facingRight;
        private int timer;
        private IPlayer owner;
        private float spawnGroundSpeed;

        public Fireball(int x, int y, bool facingRight, float spawnSpeed, IPlayer shooter)
        {
            spawnGroundSpeed = Math.Abs(spawnSpeed) > 0.5 ? spawnSpeed : UtilityClass.zero;
            location = new Vector2(x, y);
            sprite = new FireballSprite(location);
            testForCollision = true;
            timer = UtilityClass.fireballTimer;
            rigidbody = new AutonomousPhysicsObject();
            this.facingRight = facingRight;
            owner = shooter;
            LoadRigidBodyProperties();
            SoundEffectFactory.Fireball();
        }
        private void LoadRigidBodyProperties()
        {
            rigidbody.AirFriction = UtilityClass.fireballAirFriction;
            rigidbody.GroundFriction = UtilityClass.fireballGroundFriction;
            rigidbody.MaxFallSpeed = UtilityClass.fireballMaxFallSpeed;
            rigidbody.Elasticity = UtilityClass.fireballElasticity;
            rigidbody.GroundSpeed = UtilityClass.fireballRightGroundSpeed + spawnGroundSpeed;
            rigidbody.GroundSpeed *= facingRight ? 1 : -1;
            //if (facingRight) { rigidbody.GroundSpeed = UtilityClass.fireballRightGroundSpeed; }
            //else{ rigidbody.GroundSpeed = UtilityClass.fireballLeftGroupSpeed; }
            rigidbody.IsEnabled = true;
        }

        public void Update()
        {
            if (testForCollision&&timer>UtilityClass.zero)
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
        public void updateLocation(Vector2 sentLocation)
        {
            location = sentLocation;
            ((FireballSprite)(sprite)).Update(location);
        }
        public AutonomousPhysicsObject RigidBody()
        {
            return rigidbody;
        }

        public bool DoneFireBall()
        {
            bool complete = false;
            if (timer == UtilityClass.zero)
            {
                complete = true;
            }
            return complete;
        }
        public IPlayer GetOwner()
        {
            return owner;
        }
        public void Kill()
        {
            timer = UtilityClass.zero;
        }
    }
}
