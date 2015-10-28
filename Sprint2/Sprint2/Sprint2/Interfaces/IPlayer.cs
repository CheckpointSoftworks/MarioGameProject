using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public interface IPlayer
    {
        void Update();

        void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc);

        Rectangle returnCollisionRectangle();
        Vector2 returnLocation();
    }
}
