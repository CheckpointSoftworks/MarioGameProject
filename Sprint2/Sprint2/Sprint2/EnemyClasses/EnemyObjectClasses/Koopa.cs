using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class Koopa: IEnemyObject
    {
        private ISprite koopaSprite;
        private Vector2 location;
        private Rectangle collisionRectangle;
        private Vector2 velocity;
        private float walkSpeed;
        private float shellSlideSpeed;
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

        public Koopa(int locX, int locY)
        {
            location = new Vector2(locX, locY);
            koopaSprite = EnemySpriteFactory.CreateGreenKoopaSprite(location);
            collisionRectangle = koopaSprite.returnCollisionRectangle();
            isDamaged = false;
            walkSpeed = 0.7f;
            shellSlideSpeed = 1.4f;
            gravity.X = 0;
            gravity.Y = 6.0f;
            decayRate = 0.90f;
            FallLeft();
        }
        public void MoveLeft()
        {
            isFalling = false;
            if (isDamaged)
            {
                velocity.X = -shellSlideSpeed;
            }
            else
            {
                velocity.X = -walkSpeed;
                ((KoopaSprite)koopaSprite).FacingRight = false;
            }
        }
        public void MoveRight()
        {
            isFalling = false;
            if (isDamaged)
            {
                velocity.X = shellSlideSpeed;
            }
            else
            {
                velocity.X = walkSpeed;
                ((KoopaSprite)koopaSprite).FacingRight = true;
            }
        }
        public void FallLeft()
        {
            isFalling = true;
            if (isDamaged) {
                velocity.X = -shellSlideSpeed;
            }
            else
            {
                velocity.X = -walkSpeed;
                ((KoopaSprite)koopaSprite).FacingRight = false;
            }
            velocity.X = -walkSpeed;
        }
        public void FallRight()
        {
            isFalling = true;
            if (isDamaged)
            {
                velocity.X = shellSlideSpeed;
            }
            else
            {
                velocity.X = walkSpeed;
                ((KoopaSprite)koopaSprite).FacingRight = true;
            }
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
                ((KoopaShellSprite)koopaSprite).Location = location;
            }
            else
            {
                ((KoopaSprite)koopaSprite).Location = location;
            }
            koopaSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            koopaSprite.Draw(spriteBatch);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }

        public void TakeDamage()
        {
            isDamaged = true;
            koopaSprite = EnemySpriteFactory.CreateGreenKoopaShellSprite(location);
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
