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
        private Vector2 location;
        private Texture2D GoombaSpriteSheet;
        private AnimatedSprite AnimatedGoomba;
        private bool FacingRight = true;

        public GoombaSprite(Texture2D goombaSpritesheet)
        {
            location = new Vector2(600, 150);
            GoombaSpriteSheet = goombaSpritesheet;
            AnimatedGoomba = new AnimatedSprite(goombaSpritesheet, 1, 2);


        }
        public void Update()
        {

            AnimatedGoomba.Update();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            AnimatedGoomba.Draw(spriteBatch, location, FacingRight);

        }
    }
}
