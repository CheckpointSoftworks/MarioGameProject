using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public interface IItemObjects
    {
        void Update();

        void LeftCollision();
        void RightCollision();
        void TopCollision();
        void BottomCollision();
        AutonomousPhysicsObject GetRigidBody();

        void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc);

        ItemType returnItemType();

        Rectangle returnCollisionRectangle();

        void setCollisionRectangle(Rectangle collisionRectangle);

        bool checkForCollisionTestFlag();

        Vector2 returnLocation();

        void updateLocation(Vector2 location);
    }
}
