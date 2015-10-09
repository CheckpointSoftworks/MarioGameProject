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
        private AnimatedSprite AnimatedKoopa;
        private bool FacingRight = true;

        public KoopaSprite(Texture2D koopaSpritesheet,Vector2 location)
        {
            this.location = location;
            AnimatedKoopa = new AnimatedSprite(koopaSpritesheet, 1, 2,location);
        }
        public void Update()
        {

            AnimatedKoopa.Update();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            AnimatedKoopa.Draw(spriteBatch, location, FacingRight);

        }

        public Rectangle returnCollisionRectangle()
        {
            return AnimatedKoopa.returnCollisionRectangle();
        }
    }
}
