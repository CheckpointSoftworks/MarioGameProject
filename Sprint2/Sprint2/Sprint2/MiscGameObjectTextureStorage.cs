using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint2
{
    class MiscGameObjectTextureStorage
    {
        private static Texture2D pipeSpriteSheet;

        public static void Load(ContentManager content)
        {
            pipeSpriteSheet = content.Load<Texture2D>("PipeSprite");
        }

        public static Texture2D CreatePipeSprite()
        {
            return pipeSpriteSheet;
        }
    }
}
