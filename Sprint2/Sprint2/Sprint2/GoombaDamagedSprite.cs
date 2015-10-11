using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class GoombaDamagedSprite:ISprite
    {
        private Vector2 location;
        private AnimatedSprite AnimatedDamGoomba;
        private bool FacingRight = true;

        public GoombaDamagedSprite(Texture2D goombaDamSpritesheet,Vector2 location)
        {
            this.location = location; 
            AnimatedDamGoomba = new AnimatedSprite(goombaDamSpritesheet, 1, 1,location);


        }
        public void Update()
        {
            AnimatedDamGoomba.Update();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            AnimatedDamGoomba.Draw(spriteBatch, location, FacingRight);

        }

        public Rectangle returnCollisionRectangle()
        {
            return AnimatedDamGoomba.returnCollisionRectangle();
        }
    }
}
