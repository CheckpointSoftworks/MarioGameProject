using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class Pipe : IEnviromental
    {
        private ISprite pipeSprite;

        public Pipe(Vector2 location)
        {
            pipeSprite = new PipeSprite(location);
        }

        public void Update()
        {
            pipeSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pipeSprite.Draw(spriteBatch);
        }

        public Rectangle returnCollisionRectangle()
        {
            return pipeSprite.returnCollisionRectangle();
        }
    }
}
