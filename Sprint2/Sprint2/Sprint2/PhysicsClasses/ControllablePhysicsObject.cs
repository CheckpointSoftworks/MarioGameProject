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
        private float deltaTime = UtilityClass.deltaTime;
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
                friction.X = Clamp(value, UtilityClass.zero, UtilityClass.one);
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
                friction.Y = Clamp(value, UtilityClass.zero, UtilityClass.one);
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
                elasticity = Clamp(value, UtilityClass.zero, UtilityClass.one);
            }
        }

        private bool floored;
        public bool Floored
        {
            get { return floored; }
            set
            {
                floored = value;
                airTime = floored ? UtilityClass.zero : airTime;
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
            velocity = new Vector2(UtilityClass.zero, UtilityClass.zero);
            elasticity = UtilityClass.zero;
            grav = new Vector2(UtilityClass.zero, UtilityClass.gravY);
        }

        public ControllablePhysicsObject(Vector2 gravity)
        {
            velocity = new Vector2(UtilityClass.zero, UtilityClass.zero);
            elasticity = UtilityClass.zero;
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
            if (Math.Abs(velocity.X) < UtilityClass.pointOne) velocity.X = UtilityClass.zero;
            if (Math.Abs(velocity.Y) < UtilityClass.pointOne) velocity.Y = UtilityClass.zero;
        }
        private void ClampAcceleration()
        {
            acceleration = Clamp(acceleration, -Math.Abs(acceleration.X), Math.Abs(acceleration.X), -maxVelocity.Y * grav.Y * (UtilityClass.one / deltaTime), maxVelocity.Y * grav.Y * (UtilityClass.one / deltaTime));
            if (Math.Abs(acceleration.Y) <= grav.Y * (grav.Y * elasticity)) acceleration.Y = UtilityClass.zero;
        }

        public void MoveRight()
        {
            acceleration.X += groundSpeed;
        }

        public void MoveLeft()
        {
            acceleration.X -= groundSpeed;
            Clamp(Velocity.X, UtilityClass.zero, maxVelocity.X);
        }
        public void ResetJump()
        {
            airTime = UtilityClass.zero;
        }

        public void Jump()
        {
            if (airTime < jumpDuration)
            {
                acceleration.Y = jumpSpeed;
                airTime += deltaTime;
            }
        }

        public void NoJump()
        {
            airTime = jumpDuration;
        }

        public void HorizontalCollision()
        {
            velocity.X = UtilityClass.zero;
        }

        public void TopCollision()
        {
            airTime = UtilityClass.airTime;
            velocity.Y = UtilityClass.zero;
            acceleration.Y = UtilityClass.zero;
            floored = false;
        }

        public void BottomCollision()
        {
            if (!floored)
            {
                floored = true;
                if (true)
                {
                    if (acceleration.Y > UtilityClass.zero) acceleration.Y *= -UtilityClass.one * elasticity;
                    ClampAcceleration();
                }

            }
            ResetJump();
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

