using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public interface IPole
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc);
    }
}
