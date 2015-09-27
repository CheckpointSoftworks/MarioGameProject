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

        private Vector2 location;
        private Texture2D KoopaSpriteSheet;
        private AnimatedSprite AnimatedKoopa;
        private bool FacingRight = true;

        public KoopaSprite(Texture2D koopaSpritesheet)
        {
            location = new Vector2(700, 150);
            KoopaSpriteSheet = koopaSpritesheet;
            AnimatedKoopa = new AnimatedSprite(koopaSpritesheet, 1, 2);


        }
        public void Update()
        {

            AnimatedKoopa.Update();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            AnimatedKoopa.Draw(spriteBatch, location, FacingRight);

        }
    }
}
