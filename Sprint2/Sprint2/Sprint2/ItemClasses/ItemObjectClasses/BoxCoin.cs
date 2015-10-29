using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BoxCoin : IItemObjects
    {
        private ISprite boxCoinSprite;
        private ItemType type;
        private Rectangle collisonRectangle;
        private Vector2 location;
        private Vector2 velocity;
        private float moveSpeed;
        private float decayRate;
        private int timer;
        private bool animate;
        private bool testForCollision;
        private AutonomousPhysicsObject rigidbody;

        public BoxCoin(int locX, int locY)
        {
            location = new Vector2(locX, locY);
            boxCoinSprite = new BoxCoinSprite(location);
            type = ItemType.Coin;
            collisonRectangle = boxCoinSprite.returnCollisionRectangle();
            testForCollision =true;
            moveSpeed = -4.25f;
            decayRate = 0.32f;
            animate = true;
            timer = 30;            
        }

        public void Update()
        {
            if (animate)
            {
                if (timer > 0)
                {
                    moveSpeed += decayRate;
                    velocity.Y = moveSpeed;
                    location = new Vector2(location.X, location.Y + velocity.Y);
                    timer--;
                }
                else
                {
                    setCollisionRectangle(new Rectangle(0, 0, 0, 0));
                }
            }
            if (testForCollision)
            {
                ((BoxCoinSprite)boxCoinSprite).Location = location;
            }
            boxCoinSprite.Update();
        }
        public ItemType returnItemType()
        {
            return type;
        }
        public Rectangle returnCollisionRectangle()
        {
            return collisonRectangle;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            boxCoinSprite.Draw(spriteBatch, cameraLoc);
        }

        public void setCollisionRectangle(Rectangle collisionRectangle)
        {
            this.collisonRectangle = collisionRectangle;
            testForCollision = false;
            boxCoinSprite = new UsedItemSprite(location);
        }

        public bool checkForCollisionTestFlag()
        {
            return testForCollision;
        }
        public Vector2 returnLocation()
        {
            return location;
        }
        public void updateLocation(Vector2 location)
        {
            this.location = location;
        }

        public AutonomousPhysicsObject RigidBody()
        {
            return rigidbody;
        }
    }
}
