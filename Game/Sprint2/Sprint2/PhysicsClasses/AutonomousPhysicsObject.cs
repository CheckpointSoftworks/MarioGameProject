using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class AutonomousPhysicsObject
    {
        public AutonomousPhysicsObject()
        {
            velocity = new Vector2(UtilityClass.zero, UtilityClass.zero);
            elasticity = UtilityClass.zero;
            grav = new Vector2(UtilityClass.zero, UtilityClass.gravY);
            acceleration = new Vector2(UtilityClass.zero, initialAirSpeed / deltaTime);

        }

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
            set
            {
                velocity = value;
            }
        }

        private float maxFallSpeed;
        public float MaxFallSpeed
        {
            get
            {
                return maxFallSpeed;
            }
            set
            {
                maxFallSpeed = value;
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

        private float initialAirSpeed;
        public float InitialAirSpeed
        {
            get
            {
                return initialAirSpeed;
            }
            set
            {
                initialAirSpeed = value;
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

        private static Vector2 grav;
        public static Vector2 Gravity
        {
            set
            {
                grav = value;
            }
            get
            {
                return grav;
            }
        }

        private bool floored;
        public bool Floored
        {
            get { return floored; }
            set { floored = value; }
        }

        public void UpdatePhysics()
        {
            if (enabled)
            {
                if (!floored) { acceleration += grav; }
                velocity = acceleration * deltaTime;
                velocity.X += groundSpeed;
                DampenVelocity();
                ClampVelocity();
            }
        }

        private void DampenVelocity()
        {
            velocity = new Vector2(velocity.X * friction.X, velocity.Y * friction.Y);
        }

        private void ClampVelocity()
        {
            velocity = Clamp(velocity, -Math.Abs(groundSpeed), Math.Abs(groundSpeed), -maxFallSpeed, maxFallSpeed);
            if (Math.Abs(velocity.X) <= UtilityClass.pointFour) velocity.X = UtilityClass.zero;
            if (Math.Abs(velocity.Y) <= UtilityClass.pointFour) velocity.Y = UtilityClass.zero;
        }

        private void ClampAcceleration()
        {
            acceleration = Clamp(acceleration, -Math.Abs(acceleration.X), Math.Abs(acceleration.X), -maxFallSpeed * grav.Y * (UtilityClass.one / deltaTime), maxFallSpeed * grav.Y * (UtilityClass.one / deltaTime));
            if (Math.Abs(acceleration.Y) < grav.Y * (grav.Y * elasticity)) acceleration.Y = UtilityClass.zero;
        }

        public void RightCollision()
        {
            if (velocity.X > UtilityClass.zero)
            {
                velocity.X = UtilityClass.zero;
                groundSpeed *= -UtilityClass.one;
            }
        }

        public void LeftCollision()
        {
            if (velocity.X < UtilityClass.zero)
            {
                velocity.X = UtilityClass.zero;
                groundSpeed *= -UtilityClass.one;
            }
        }

        public void TopCollision()
        {
            velocity.Y = UtilityClass.zero;
            if (acceleration.Y < UtilityClass.zero) acceleration.Y *= -UtilityClass.one * elasticity;
            ClampAcceleration();
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

