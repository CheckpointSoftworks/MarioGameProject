using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace IansCSharpGame
{
    interface ISprite
    {
        Texture2D Texture { get; set; }
        int Rows { get; set; }
        int Columns { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
