using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class Goomba: IEnemyObject
    {
        private ISprite goombaSprite;
        private Vector2 location;
        private Rectangle collisionRectangle;
        private Vector2 velocity;
        private float walkSpeed;
        private Vector2 gravity;
        private float decayRate;
        private bool isFalling;
        private bool isDamaged;
        private bool directionLeft;
        public bool DirectionLeft
        {
            get { return directionLeft; }
            set { directionLeft = value; }
        }
        public Vector2 Gravity
        {
            get { return gravity; }
            set { gravity = value; }
        }
        public Goomba(int locX, int locY)
        {
            location = new Vector2(locX, locY);
            goombaSprite = EnemySpriteFactory.CreateGoombaSprite(location);
            collisionRectangle = goombaSprite.returnCollisionRectangle();
            isDamaged = false;
            walkSpeed = 0.7f;
            gravity.X = 0;
            gravity.Y = 6.0f;
            decayRate = 0.90f;
            FallLeft();
        }

        public void MoveLeft()
        {
            isFalling = false;
            velocity.X = -walkSpeed;
        }
        public void MoveRight()
        {
            isFalling = false;
            velocity.X = walkSpeed;
        }
        public void FallLeft()
        {
            isFalling = true;
            velocity.X = -walkSpeed;
        }
        public void FallRight()
        {
            isFalling = true;
            velocity.X = walkSpeed;
        }
        public void StopMoving()
        {
            isFalling = false;
            velocity.X = 0;
        }
        public void Update()
        {
            velocity.Y = 0;
            velocity += gravity;
            location += velocity;
            if (isFalling)
            {
                velocity.X *= decayRate;
            }
            if (isDamaged)
            {
                ((GoombaDamagedSprite)goombaSprite).Location = location;
            }
            else
            {
                ((GoombaSprite)goombaSprite).Location = location;
            }
            goombaSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            goombaSprite.Draw(spriteBatch);
        }

        public Rectangle returnCollisionRectangle()
        {
            if (!isDamaged)
            {
                collisionRectangle = goombaSprite.returnCollisionRectangle();
            }
            else
            {
                collisionRectangle = new Rectangle(0, 0, 0, 0);
            }
            return collisionRectangle;
        }

        public void TakeDamage()
        {
            isDamaged = true;
            goombaSprite = EnemySpriteFactory.CreateGoombaDamangedSprite(location);
            collisionRectangle = new Rectangle(0, 0, 0, 0);
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
