using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public interface IProjectile
    {
        void Update();

        void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc);

        Rectangle returnCollisionRectangle();

        bool checkForCollisionTestFlag();

        Vector2 returnLocation();

        void updateLocation(Vector2 location);

        AutonomousPhysicsObject RigidBody();
        bool Active();
        ProjectileType ReturnProjectileType();
    }
}
