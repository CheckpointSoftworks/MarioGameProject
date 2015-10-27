using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class KoopaShellSprite:ISprite
    {
        private AnimatedSprite AnimatedKoopa;
        private bool FacingRight = false;
        private Vector2 location;
        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }

        public KoopaShellSprite(Texture2D koopaSpritesheet,Vector2 location)
        {
            this.location = location;
            AnimatedKoopa = new AnimatedSprite(koopaSpritesheet, 1, 1,location, 8);
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
