using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

public class ControllablePhysicsObject
{
    // A controllable physics object is a physics object which has Commands to move in every direction but down. 
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

    private Vector2 maxVelocity;
    public float maxVelocityX
    {
        set
        {
            maxVelocity.X = value;
        }
    }
    public float maxVelocityY
    {
        set
        {
            maxVelocity.Y = value;
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
            friction.X = Clamp(value,0,1);
        }
    }

    private float jumpDuration;
    private float airTime;
    public float JumpDuration
    {
        set
        {
            jumpDuration = value;
        }
    }
    private float jumpSpeed;
    public float JumpSpeed
    {
        set
        {
            jumpSpeed = value;
        }
    }

    public float AirFriction
    {
        set
        {
            friction.Y = Clamp(value,0,1);
        }
    }

    private float elasticity;

    private static Vector2 g;
    public static Vector2 Gravity
    {
        set
        {
            g = value;
        }
    }

    public ControllablePhysicsObject()
    {
        velocity = new Vector2(0, 0);
        elasticity = 0;
        g = new Vector2(0, 30f);
    }

    public ControllablePhysicsObject(Vector2 gravity)
    {
        // For special cases like water, space, or sideways levels
        velocity = new Vector2(0, 0);
        elasticity = 0;
        g = gravity;
    }

    public void UpdatePhysics()
    {
        if (enabled)
        {
            velocity += g;
            DampenVelocity();
            ClampVelocity();
        }
        else { Console.WriteLine("Physics object not enabled."); }
    }

    private void DampenVelocity()
    {
        velocity = new Vector2(velocity.X * friction.X, velocity.Y * friction.Y);
    }

    private void ClampVelocity()
    {
        velocity = Clamp(velocity, -maxVelocity.X, maxVelocity.X, -maxVelocity.Y, maxVelocity.Y);
    }

    public void MoveRight()
    {
        velocity.X += groundSpeed;
        Clamp(Velocity.X, 0, maxVelocity.X);
    }

    public void MoveLeft()
    {
        velocity.X -= groundSpeed;
        Clamp(Velocity.X, 0, maxVelocity.X);
    }

    public void Jump()
    {
        if (airTime < jumpDuration)
        {
            velocity.Y = jumpSpeed;
            airTime += 0.1f;
            Console.WriteLine("Jump!" + " jumpspeed is " + jumpSpeed);
            //MAGIC NUMBER! This should be set to the frame rate, whether it's dynamically set or determined
        }
    }

    public void HorizontalCollision()
    {
        velocity.X = 0;
    }

    public void TopCollision()
    {
        velocity.Y = 0;
    }

    public void BottomCollision()
    {
        Console.WriteLine("Bottom collision");
        velocity.Y = 0;
        airTime = 0;
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
        return new Vector2 (Clamp(value.X,xMin,xMax),Clamp(value.Y,yMin,yMax));
    }
}

