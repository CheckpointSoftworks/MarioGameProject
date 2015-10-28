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
        ISprite fireballSprite;
        Texture2D fireballSpriteSheet;
        public Vector2 location;
        public AutonomousPhysicsObject rigidbody;
        private Rectangle collisionRectangle;

        public Fireball(int x, int y)
        {
            location = new Vector2(x, y);
            fireballSpriteSheet = MiscGameObjectTextureStorage.CreateFireballSprite();
            fireballSprite = new FireballSprite(fireballSpriteSheet, location, this);
            collisionRectangle = fireballSprite.returnCollisionRectangle();
            rigidbody = new AutonomousPhysicsObject();
            LoadPhysicsProperties();
        }

        private void LoadPhysicsProperties()
        {
            rigidbody.AirFriction = 1f;
            rigidbody.GroundFriction = 1f;
            rigidbody.GroundSpeed = 1f;
            rigidbody.MaxFallSpeed = 3f;
            rigidbody.Elasticity = 0.6f;
            rigidbody.IsEnabled = true;
        }

        public void Update()
        {
            rigidbody.UpdatePhysics();
            location += rigidbody.Velocity;
            fireballSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            fireballSprite.Draw(spriteBatch, cameraLoc);

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

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }

        public Vector2 returnLocation()
        {
            return location;
        }
    }
}
