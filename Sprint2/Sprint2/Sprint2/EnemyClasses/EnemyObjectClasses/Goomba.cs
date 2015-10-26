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
        private float fallSpeed;
        private float decayRate;
        private bool isFalling;
        private bool isDamaged;
        private bool previousMovingDirectionLeft;
        public bool PreviousMovingDirectionLeft
        {
            get { return previousMovingDirectionLeft; }
            set { previousMovingDirectionLeft = value; }
        }

        public Goomba(int locX, int locY)
        {
            location = new Vector2(locX, locY);
            goombaSprite = EnemySpriteFactory.CreateGoombaSprite(location);
            collisionRectangle = goombaSprite.returnCollisionRectangle();
            isDamaged = false;
            walkSpeed = 0.7f;
            fallSpeed = 6.0f;
            decayRate = 0.98f;
            FallLeft();
        }

        public void MoveLeft()
        {
            isFalling = false;
            velocity.X = -walkSpeed;
            velocity.Y = 0;
        }
        public void MoveRight()
        {
            isFalling = false;
            velocity.X = walkSpeed;
            velocity.Y = 0;
        }
        public void FallLeft()
        {
            isFalling = true;
            velocity.X = -walkSpeed;
            velocity.Y = fallSpeed;
        }
        public void FallRight()
        {
            isFalling = true;
            velocity.X = walkSpeed;
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
            return collisionRectangle;
        }

        public void TakeDamage()
        {
            isDamaged = true;
            goombaSprite = EnemySpriteFactory.CreateGoombaDamangedSprite(location);
            collisionRectangle = new Rectangle(0, 0, 0, 0);
        }
    }
}
