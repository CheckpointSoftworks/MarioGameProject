using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class SuperMushroom : IItemObjects
    {
        private ISprite superMushroomSprite;
        private ItemType type;
        private Rectangle collisionRectangle;
        private Vector2 location;
        private Vector2 velocity;
        private float riseSpeed;
        private float slideSpeed;
        private float fallSpeed;
        private float decayRate;
        private bool testForCollision;
        private bool isFalling;
        private bool directionLeft;
        public bool DirectionLeft
        {
            get { return directionLeft; }
            set { directionLeft = value; }
        }

        public SuperMushroom(int locX, int locY)
        {
            location = new Vector2(locX, locY);
            superMushroomSprite = new SuperMushroomSprite(location);
            type = ItemType.SuperMushroom;
            collisionRectangle = superMushroomSprite.returnCollisionRectangle();
            testForCollision=true;
            riseSpeed = 0.5f;
            slideSpeed = 1.0f;
            fallSpeed = 6.0f;
            decayRate = 0.98f;
        }
        public void RiseUp()
        {
            velocity.X = 0;
            velocity.Y = -riseSpeed;
        }
        public void MoveLeft()
        {
            isFalling = false;
            velocity.X = -slideSpeed;
            velocity.Y = 0;
        }
        public void MoveRight()
        {
            isFalling = false;
            velocity.X = slideSpeed;
            velocity.Y = 0;
        }
        public void FallLeft()
        {
            isFalling = true;
            velocity.X = -slideSpeed;
            velocity.Y = fallSpeed;
        }
        public void FallRight()
        {
            isFalling = true;
            velocity.X = slideSpeed;
            velocity.Y = fallSpeed;
        }
        public void StopMoving()
        {
            isFalling = false;
            velocity.X = 0;
            velocity.Y = 0;
        }
        public void Update()
        {
            location += velocity;
            if (isFalling)
            {
                velocity.X *= decayRate;
            }
            if (testForCollision)
            {
                ((SuperMushroomSprite)superMushroomSprite).Location = location;
            }
            superMushroomSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            superMushroomSprite.Draw(spriteBatch);
        }
        public ItemType returnItemType()
        {
            return type;
        }
        public void setCollisionRectangle(Rectangle sentCollisionRectangle)
        {
            collisionRectangle = sentCollisionRectangle;
            testForCollision=false;
            superMushroomSprite =new UsedItemSprite(location);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
        public bool checkForCollisionTestFlag()
        {
            return testForCollision;
        }


    }
}
