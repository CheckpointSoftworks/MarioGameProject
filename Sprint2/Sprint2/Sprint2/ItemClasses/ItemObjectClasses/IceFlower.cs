using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class IceFlower : IItemObjects
    {
        private NonPlayerScoreItem score;
        private ISprite iceFlowerSprite;
        private ItemType type;
        private Rectangle collisonRectangle;
        private Vector2 location;
        private Vector2 velocity;
        private float riseSpeed;
        private bool testForCollision;
        private AutonomousPhysicsObject rigidbody;

        public IceFlower(int locX, int locY)
        {
            score = new NonPlayerScoreItem(UtilityClass.itemScore, false);
            location = new Vector2(locX, locY);
            iceFlowerSprite = new IceFlowerSprite(location);
            type = ItemType.IceFlower;
            collisonRectangle = iceFlowerSprite.returnCollisionRectangle();
            testForCollision = true;
            riseSpeed = UtilityClass.iceFlowerRiseSpeed;
            rigidbody = new AutonomousPhysicsObject();
        }
        public NonPlayerScoreItem ScoreData()
        {
            return score;
        }
        public ItemType returnItemType()
        {
            return type;
        }
        public Rectangle returnCollisionRectangle()
        {
            return collisonRectangle;
        }
        public void RiseUp()
        {
            velocity.X = UtilityClass.zero;
            velocity.Y = -riseSpeed;
        }
        public void StopMoving()
        {
            velocity.X = UtilityClass.zero;
            velocity.Y = UtilityClass.zero;
        }
        public void Update()
        {
            location += velocity;
            if (testForCollision)
            {
                ((IceFlowerSprite)iceFlowerSprite).Location = location;
            }
            iceFlowerSprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            iceFlowerSprite.Draw(spriteBatch, cameraLoc);
        }
        public void setCollisionRectangle(Rectangle collisionRectangle)
        {
            this.collisonRectangle = collisionRectangle;
            testForCollision = false;
            iceFlowerSprite = new UsedItemSprite(location);
        }
        public bool checkForCollisionTestFlag()
        {
            return testForCollision;
        }
        public Vector2 returnLocation()
        {
            return location;
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