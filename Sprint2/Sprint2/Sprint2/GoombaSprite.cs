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
        private AnimatedSprite AnimatedGoomba;
        private bool FacingRight = true;

        public GoombaSprite(Texture2D goombaSpritesheet,Vector2 location)
        {
            //Replace this
            this.location = location; 
            AnimatedGoomba = new AnimatedSprite(goombaSpritesheet, 1, 2,location);


        }
        public void Update()
        {


            AnimatedGoomba.Update();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            AnimatedGoomba.Draw(spriteBatch, location, FacingRight);

        }

        public Rectangle returnCollisionRectangle()
        {
            return AnimatedGoomba.returnCollisionRectangle();
        }
    }
}
