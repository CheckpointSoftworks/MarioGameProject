using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class OneUpMushroom : IItemObjects
    {
        private ISprite oneUpMushroomSprite;
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

        public OneUpMushroom(int locX, int locY)
        {
            location = new Vector2(locX, locY);
            oneUpMushroomSprite = new OneUpMushroomSprite(location);
            type = ItemType.OneUpMushroom;
            collisionRectangle = oneUpMushroomSprite.returnCollisionRectangle();
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
                ((OneUpMushroomSprite)oneUpMushroomSprite).Location = location;
            }
            oneUpMushroomSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            oneUpMushroomSprite.Draw(spriteBatch);
        }

        public void setCollisionRectangle(Rectangle sentCollisionRectangle)
        {
            collisionRectangle = sentCollisionRectangle;
            testForCollision=false;
            oneUpMushroomSprite = new UsedItemSprite(location);
        }
        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
        public ItemType returnItemType()
        {
            return type;
        }
        public bool checkForCollisionTestFlag()
        {
            return testForCollision;
        }
    }
}
