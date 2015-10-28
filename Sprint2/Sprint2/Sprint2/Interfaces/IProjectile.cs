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

        void LeftCollision();
        void RightCollision();
        void TopCollision();
        void BottomCollision();

        void updateLocation(Vector2 location);

        Rectangle returnCollisionRectangle();
        Vector2 returnLocation();

    }
}
