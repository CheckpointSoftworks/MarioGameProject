using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class SuperStar : IItemObjects
    {
        private ISprite sprite;

        private Rectangle collisionRectangle;
        private ItemType type;
        private bool testForCollision;
        private Vector2 location;
        private bool directionLeft;
        private AutonomousPhysicsObject rigidbody;

        public SuperStar(int locX, int locY)
        {
            location = new Vector2(locX, locY);
            sprite = new SuperStarSprite(location);
            type = ItemType.Star;
            collisionRectangle = sprite.returnCollisionRectangle();
            testForCollision = true;
            rigidbody = new AutonomousPhysicsObject();
            LoadRigidBodyProperties();
        }

        public bool DirectionLeft
        {
            get { return directionLeft; }
            set { directionLeft = value; }
        }
        private void LoadRigidBodyProperties()
        {
            rigidbody.AirFriction = 0.8f;
            rigidbody.GroundFriction = 1f;
            rigidbody.GroundSpeed = 1f;
            rigidbody.InitialAirSpeed = 3f;
            rigidbody.MaxFallSpeed = 3f;
            rigidbody.Elasticity = 1f;
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
        public AutonomousPhysicsObject GetRigidBody()
        {
            return rigidbody;
        }


        public void Update()
        {
            rigidbody.UpdatePhysics();
            location += rigidbody.Velocity;
            if (testForCollision)
            {
                ((SuperStarSprite)(sprite)).Update(location);
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

        public ItemType returnItemType()
        {
            return type;
        }
        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }

        public void setCollisionRectangle(Rectangle sentCollisionRectangle)
        {
            collisionRectangle = sentCollisionRectangle;
            testForCollision = false;
            sprite = new UsedItemSprite(location);
        }
        public bool checkForCollisionTestFlag()
        {
            return testForCollision;
        }
        public void updateLocation(Vector2 location)
        {
            this.location = location;
        }
    }
}