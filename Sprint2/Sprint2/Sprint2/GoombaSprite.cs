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
        private Vector2 location;
        private Texture2D GoombaSpriteSheet;

        public GoombaSprite(Texture2D goombaSpritesheet)
        {
            //Replace this
            location = new Vector2(50, 50);
            GoombaSpriteSheet = goombaSpritesheet;


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
            int spriteWidth = 16;
            int spriteHeight = 16;
            Rectangle sourceRectangle = new Rectangle();
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, spriteWidth, spriteHeight);


            if (currentFrame < 10)
            {
                sourceRectangle = new Rectangle(0, 4, 16, 16);
            }
            if (currentFrame >= 10)
            {
                sourceRectangle = new Rectangle(30, 4, 16, 16);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(GoombaSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();

        }
    }
}
