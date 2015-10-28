﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

public class AutonomousPhysicsObject
{
    // An autonomous physics object is a physics object which has a set velocity that never changes. This is for enemies, projectiles, etc.
    // Physics should be updated before collision handling. That said, physics should be included in collision handling so velocites can be reset. 

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

    private float maxFallSpeed;
    public float MaxFallSpeed
    {
        set
        {
            maxFallSpeed = value;
        }
    }
    private float groundSpeed;
    public float GroundSpeed
    {
        set
        {
            groundSpeed = value;
        }
    }
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

    private float elasticity;
    public float Elasticity
    {
        //Elasticity is the amount of momentum retained after a collision. 0 would be like a car hitting an immovable object, 1 would be like dropping a bouncy ball and having it bounce forever. 
        //The extrema are physically impossible in the real world, but for the game's sake, they're allowed. The Star has an elasticity of 1 for example. 
        get
        {
            return elasticity;
        }
        set
        {
            elasticity = Clamp(value, 0, 1);
        }
    }

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
        g = new Vector2(0, 4f);
    }

    public AutonomousPhysicsObject(Vector2 gravity)
    {
        // For special cases like water, space, or sideways levels
        velocity = new Vector2(0, 0);
        elasticity = 0;
        g = gravity;
    }

    public void UpdatePhysics()
    {
        //Console.WriteLine("At start of physics update, vel is " + velocity);
        if (enabled)
        {
            if (!floored) { velocity += g; }
            velocity.X += groundSpeed;
            //MAGIC NUMBER
            DampenVelocity();
            ClampVelocity();
        }
        else { Console.WriteLine("Physics object not enabled."); }
        //Console.WriteLine("At end of physics update, vel is " + velocity);
    }

    private void DampenVelocity()
    {
        velocity = new Vector2(velocity.X * friction.X, velocity.Y * friction.Y);
    }

    private void ClampVelocity()
    {
        velocity = Clamp(velocity, -Math.Abs(groundSpeed), Math.Abs(groundSpeed), -maxFallSpeed, maxFallSpeed);
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
        floored = false;
    }

    public void BottomCollision()
    {
        floored = true;
        velocity.Y = 0;
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

