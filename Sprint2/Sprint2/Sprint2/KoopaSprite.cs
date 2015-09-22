using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class KoopaSprite : ISprite
    {

        private int currentFrame;

        public KoopaSprite(Texture2D goombaSpritesheet, Game1 game)
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
                sourceRectangle = new Rectangle(149, 0, 18, 24);
            }
            if (currentFrame >= 10)
            {
                sourceRectangle = new Rectangle(179, 0, 18, 24);
            }

        }
    }
}
