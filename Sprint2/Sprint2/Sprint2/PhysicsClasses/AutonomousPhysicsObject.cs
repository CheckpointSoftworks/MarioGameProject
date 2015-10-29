using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

public class AutonomousPhysicsObject
{
    // An autonomous physics object is a physics object which has a set velocity that never changes. This is for enemies, projectiles, etc.
    // Physics should be updated before collision handling. That said, physics should be included in collision handling so velocites can be reset. 

    // This is the time since the last update. It can stay as 0.1 or we can use the actual GameTime.DeltaTime if it exists. 
    // This is used to make sure physics is fully accurate. I can't go into here, but check the slides to see why this value exists. 
    private float deltaTime = 0.1f;

    // Will the object use physics? Set enable to false if it shouldn't move.
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
    
    //Velocity refers to the displacement of the object 
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

    // Terminal velocity of the object, adding gravity passed this point won't make it go faster
    private float maxFallSpeed;
    public float MaxFallSpeed
    {
        set
        {
            maxFallSpeed = value;
        }
    }

    // The velocity this object moves. Can only be inverted by a collision. Ground acceleration is also 0, so ground velocity is fixed.
    private float groundSpeed;
    public float GroundSpeed
    {
        set
        {
            groundSpeed = value;
        }
    }

    private float initialAirSpeed;
    public float InitialAirSpeed
    {
        set
        {
            initialAirSpeed = value;
        }
    }

    //Friction will eventually slow the object down. It's multiplied by velocity to dampen velocity. 
    private Vector2 friction;
    public float GroundFriction
    {
        set
        {
            friction.X = Clamp(value, 0, 1);
        }
    }

    public float AirFriction
    {
        set
        {
            friction.Y = Clamp(value, 0, 1);
        }
    }

    //Acceleration is the rate of change of velocity. Because it's a rate, velocity equals acceleration (rise) multiplied by delta time (1/run)
    public Vector2 acceleration;

    //Elasticity is the amount of momentum retained after a collision. 0 would be like a car hitting an immovable object, 1 would be like dropping a bouncy ball and having it bounce forever. 
    //The extrema are physically impossible in the real world, but for the game's sake, they're allowed. The Star has an elasticity of 1 for example. 
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

    // Gravity is that thing that makes massive objects pull towards each other. It's actually significantly more complicated than that, but for our purposes assume that the ground is fixed in space.
    private static Vector2 g;
    public static Vector2 Gravity
    {
        set
        {
            g = value;
        }
        get
        {
            return g;
        }
    }

    // Has the object hit the floor this frame? If so, gravity won't be applied to make collisions less glitchy
    private bool floored;
    public bool Floored
    {
        get { return floored; }
        set { floored = value; }
    }

    public AutonomousPhysicsObject()
    {
        velocity = new Vector2(0, 0);
        elasticity = 0;
        g = new Vector2(0, 5f);
        acceleration = new Vector2(0, initialAirSpeed/deltaTime);
    }

    public AutonomousPhysicsObject(Vector2 gravity)
    {
        // For special cases like water, space, or sideways levels
        velocity = new Vector2(0, 0);
        elasticity = 0;
        g = gravity;
        acceleration = new Vector2(0, initialAirSpeed/deltaTime);
    }

    public void UpdatePhysics()
    {
        if (enabled)
        {
            if (!floored) { acceleration += g; }
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
        if (Math.Abs(velocity.X) <= 0.4) velocity.X = 0;
        if (Math.Abs(velocity.Y) <= 0.4) velocity.Y = 0;
    }

    private void ClampAcceleration()
    {
        acceleration = Clamp(acceleration, -Math.Abs(acceleration.X), Math.Abs(acceleration.X), -maxFallSpeed*g.Y*(1/deltaTime), maxFallSpeed*g.Y*(1/deltaTime));
        if (Math.Abs(acceleration.Y) < g.Y*(g.Y*elasticity)) acceleration.Y = 0;
    }

    public void RightCollision()
    {
        //Console.WriteLine("hor velocity was " + velocity);
        if (velocity.X > 0)
        {
            velocity.X = 0;
            groundSpeed *= -1;
        }
        //Console.WriteLine("hor velocity is now" + velocity);
    }

    public void LeftCollision()
    {
        if (velocity.X < 0)
        {
            velocity.X = 0;
            groundSpeed *= -1;
        }
        //Console.WriteLine("hor velocity is now" + velocity);
    }

    public void TopCollision()
    {
        velocity.Y = 0;
        if (acceleration.Y < 0) acceleration.Y *= -1 * elasticity;
        if (acceleration.Y != 0) Console.WriteLine("Acceleration after bounce " + acceleration);
        ClampAcceleration();
        floored = false;
    }

    public void BottomCollision()
    {
        //Console.WriteLine("Bottom from rb, floored? " + floored);
        if (!floored)
        {
            floored = true;
            if (true)
            {
                //Console.WriteLine("Accel is " + acceleration);
                if(acceleration.Y > 0) acceleration.Y *= -1 * elasticity;
                if (acceleration.Y != 0) Console.WriteLine("Acceleration after bounce " + acceleration);
                ClampAcceleration();
                //Console.WriteLine("Accel is now " + acceleration);
                //velocity.Y = 0;                
            }
        }
    }

    private float Clamp(float value, float min, float max)
    {
        //I'm pretty sure this function exists in the XNA, but I can't seem to find it. Feel free to cut this and replace the calls with the already written function if you can find it. 
        if (value < min || value > max)
        {
            return value < min ? min : max;
        }
        else
        {
            return value;
        }
    }

    private Vector2 Clamp(Vector2 value, float xMin, float xMax, float yMin, float yMax)
    {
        return new Vector2(Clamp(value.X, xMin, xMax), Clamp(value.Y, yMin, yMax));
    }
}

