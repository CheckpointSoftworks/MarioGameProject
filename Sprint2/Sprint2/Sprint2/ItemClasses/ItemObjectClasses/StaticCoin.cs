using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class StaticCoin : IItemObjects
    {
        private NonPlayerScoreItem score;
        private ISprite sprite;
        private Rectangle collisionRectangle;
        private ItemType type;
        private bool testForCollision;
        private Vector2 location;
        private bool directionLeft;
        private AutonomousPhysicsObject rigidbody;

        public StaticCoin(int locX, int locY)
        {
            score = new NonPlayerScoreItem(UtilityClass.coinScore, false);
            location = new Vector2(locX, locY);
            sprite = new StaticCoinSprite(location);
            type = ItemType.Coin;
            collisionRectangle = sprite.returnCollisionRectangle();
            testForCollision = true;
            rigidbody = new AutonomousPhysicsObject();
        }

        public NonPlayerScoreItem ScoreData()
        {
            return score;
        }

        public bool DirectionLeft
        {
            get { return directionLeft; }
            set { directionLeft = value; }
        }
        private void LoadRigidBodyProperties()
        {
            rigidbody.AirFriction = UtilityClass.mushroomAirFriction;
            rigidbody.GroundFriction = UtilityClass.mushroomGroundFriction;
            rigidbody.GroundSpeed = UtilityClass.mushroomGroundSpeed;
            rigidbody.MaxFallSpeed = UtilityClass.mushroomMaxFallSpeed;
            rigidbody.Elasticity = UtilityClass.mushroomElasticity;
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
            if (testForCollision)
            {
                rigidbody.UpdatePhysics();
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
            if (testForCollision)
            {
                collisionRectangle = sprite.returnCollisionRectangle();
            }
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
        public void updateLocation(Vector2 sentLocation)
        {
            location = sentLocation;
        }
        public AutonomousPhysicsObject RigidBody()
        {
            return rigidbody;
        }
    }
}
