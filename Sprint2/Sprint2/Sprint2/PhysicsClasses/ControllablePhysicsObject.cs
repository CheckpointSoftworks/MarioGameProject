using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class ControllablePhysicsObject
    {
        private float deltaTime = 0.1f;
        private bool enabled;
        public bool IsEnabled
        {
            get
            {
                return enabled;
            }
            set
            {
                enabled = value;
            }
        }
        private Vector2 velocity;
        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }
        }

        private Vector2 maxVelocity;
        public float maxVelocityX
        {
            get
            {
                return maxVelocity.X;
            }
            set
            {
                maxVelocity.X = value;
            }
        }
        public float maxVelocityY
        {
            get
            {
                return maxVelocity.Y;
            }
            set
            {
                maxVelocity.Y = value;
            }
        }

        private float groundSpeed;
        public float GroundSpeed
        {
            get
            {
                return groundSpeed;
            }
            set
            {
                groundSpeed = value;
            }
        }

        private Vector2 friction;
        public float GroundFriction
        {
            get
            {
                return friction.X;
            }
            set
            {
                friction.X = Clamp(value, 0, 1);
            }
        }

        private float jumpDuration;
        private float airTime;
        public float JumpDuration
        {
            get
            {
                return jumpDuration;
            }
            set
            {
                jumpDuration = value;
            }
        }
        private float jumpSpeed;
        public float JumpSpeed
        {
            get
            {
                return jumpSpeed;
            }
            set
            {
                jumpSpeed = value;
            }
        }

        public float AirFriction
        {
            get
            {
                return friction.Y;
            }
            set
            {
                friction.Y = Clamp(value, 0, 1);
            }
        }

        private Vector2 acceleration;

        private float elasticity;
        public float Elasticity
        {
            get
            {
                return elasticity;
            }
            set
            {
                elasticity = Clamp(value, 0, 1);
            }
        }

        private bool floored;
        public bool Floored
        {
            get { return floored; }
            set
            {
                floored = value;
                airTime = floored ? 0 : airTime;
            }
        }
        private static Vector2 grav;

        public static Vector2 Gravity
        {
            get
            {
                return grav;
            }
            set
            {
                grav = value;
            }
        }

        public ControllablePhysicsObject()
        {
            velocity = new Vector2(0, 0);
            elasticity = 0;
            grav = new Vector2(0, 5f);
        }

        public ControllablePhysicsObject(Vector2 gravity)
        {
            velocity = new Vector2(0, 0);
            elasticity = 0;
            grav = gravity;
        }

        public void UpdatePhysics()
        {
            if (enabled)
            {
                if (!floored) { acceleration += grav; }
                velocity = acceleration * deltaTime;
                DampenVelocity();
                ClampVelocity();
            }
        }

        private void DampenVelocity()
        {
            acceleration = new Vector2(acceleration.X * friction.X, acceleration.Y * friction.Y);
        }

        private void ClampVelocity()
        {
            velocity = Clamp(velocity, -maxVelocity.X, maxVelocity.X, -maxVelocity.Y, maxVelocity.Y);
            if (Math.Abs(velocity.X) < 0.1) velocity.X = 0;
            if (Math.Abs(velocity.Y) < 0.1) velocity.Y = 0;
        }
        private void ClampAcceleration()
        {
            acceleration = Clamp(acceleration, -Math.Abs(acceleration.X), Math.Abs(acceleration.X), -maxVelocity.Y * grav.Y * (1 / deltaTime), maxVelocity.Y * grav.Y * (1 / deltaTime));
            if (Math.Abs(acceleration.Y) <= grav.Y * (grav.Y * elasticity)) acceleration.Y = 0;
        }

        public void MoveRight()
        {
            acceleration.X += groundSpeed;
        }

        public void MoveLeft()
        {
            acceleration.X -= groundSpeed;
            Clamp(Velocity.X, 0, maxVelocity.X);
        }

        public void Jump()
        {
            if (airTime < jumpDuration)
            {
                acceleration.Y = jumpSpeed;
                airTime += deltaTime;
            }
        }

        public void HorizontalCollision()
        {
            velocity.X = 0;
        }

        public void TopCollision()
        {
            airTime = 100;
            velocity.Y = 0;
            acceleration.Y = 0;
            floored = false;
        }

        public void BottomCollision()
        {
            if (!floored)
            {
                floored = true;
                if (true)
                {
                    if (acceleration.Y > 0) acceleration.Y *= -1 * elasticity;
                    ClampAcceleration();
                }

            }
            airTime = 0;
        }

        private static float Clamp(float value, float min, float max)
        {
            if (value < min || value > max)
            {
                return value < min ? min : max;
            }
            else
            {
                return value;
            }
        }

        private static Vector2 Clamp(Vector2 value, float xMin, float xMax, float yMin, float yMax)
        {
            return new Vector2(Clamp(value.X, xMin, xMax), Clamp(value.Y, yMin, yMax));
        }
    }
}

