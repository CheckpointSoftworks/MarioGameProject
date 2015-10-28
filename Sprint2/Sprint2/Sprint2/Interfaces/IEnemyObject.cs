using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public interface IEnemyObject
    {
        bool DirectionLeft
        { get; set; }
        void LeftCollision();
        void RightCollision();
        void TopCollision();
        void BottomCollision();
        AutonomousPhysicsObject GetRigidBody();
        void Update();

        void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc);
                
        Rectangle returnCollisionRectangle();

        void TakeDamage();

        void updateLocation(Vector2 location);

        Vector2 returnLocation();
    
    }
}
