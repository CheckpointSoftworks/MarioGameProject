using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class PipeSprite : ISprite
    {
        private Texture2D pipeSpriteSheet;
        private Vector2 location;
        public PipeSprite()
        {
            pipeSpriteSheet = MiscGameObjectTextureStorage.CreatePipeSprite();
        }
        public void Update()
        {
            //No Update Logic Needed
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
