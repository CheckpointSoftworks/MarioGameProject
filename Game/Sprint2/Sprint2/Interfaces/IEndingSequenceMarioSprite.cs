using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public interface IEndingSequenceMarioSprite
    {
        void MarioFlagpoleDrawFacingLeft(Vector2 location, SpriteBatch spriteBatch, Vector2 cameraLoc);
        void MarioFlagpoleDrawFacingRight(Vector2 location, SpriteBatch spriteBatch, Vector2 cameraLoc);
        void MarioWalkingDraw(Vector2 location, SpriteBatch spriteBatch, Vector2 cameraLoc);
        void Update();
    }
}
