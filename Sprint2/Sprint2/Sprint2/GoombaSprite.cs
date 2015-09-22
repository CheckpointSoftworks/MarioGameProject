using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class GoombaSprite : ISprite
    {
        private int currentFrame;

        public GoombaSprite(Texture2D goombaSpritesheet, Game1 game)
        {

        }
        public void Update()
        {

            currentFrame++;
            if (currentFrame == 20)
            {
                currentFrame = 0;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Rectangle sourceRectangle = new Rectangle();

            if (currentFrame < 10)
            {
                sourceRectangle = new Rectangle(0, 4, 16, 16);
            }
            if (currentFrame >= 10)
            {
                sourceRectangle = new Rectangle(30, 4, 16, 16);
            }

        }
    }
}
