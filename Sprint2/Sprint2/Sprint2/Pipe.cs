using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class Pipe : IGameObject
    {
        private ISprite pipeSprite;

        public Pipe()
        {
            pipeSprite = new PipeSprite();
        }

        public void Update()
        {
            pipeSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pipeSprite.Draw(spriteBatch);
        }
    }
}
