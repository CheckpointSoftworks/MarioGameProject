using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public interface IEndingSequenceMario
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc, SpriteFont font);
        bool FlagAtBottom { get; set; }
        bool EndSequenceFinished { get; set; }
    }
}
