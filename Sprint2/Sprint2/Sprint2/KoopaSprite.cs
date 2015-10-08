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
        private Vector2 location;
        private Texture2D KoopaSpriteSheet;

        public KoopaSprite(Texture2D koopaSpritesheet)
        {
            //Replace this
            location = new Vector2(700, 200);
            KoopaSpriteSheet = koopaSpritesheet;

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
            int spriteHeight = 24;
            Rectangle sourceRectangle = new Rectangle(0,0,0,0);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, spriteWidth, spriteHeight);

            if (currentFrame < 10)
            {
                sourceRectangle = new Rectangle(149, 0, 18, 24);
            }
            if (currentFrame >= 10)
            {
                sourceRectangle = new Rectangle(179, 0, 18, 24);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(KoopaSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();

        }
    }
}
