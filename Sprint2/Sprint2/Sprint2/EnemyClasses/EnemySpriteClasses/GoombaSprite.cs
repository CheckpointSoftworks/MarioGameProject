using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class GoombaSprite : ISprite
    {
        private AnimatedSprite AnimatedGoomba;
        private bool FacingRight = true;
        private Vector2 location;
        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }

        public GoombaSprite(Texture2D goombaSpritesheet,Vector2 location)
        {
            this.location = location;
            AnimatedGoomba = new AnimatedSprite(goombaSpritesheet, UtilityClass.one, UtilityClass.two, location, UtilityClass.enemyTotalFramesAndMarioFlagpoleTotalFrames);
        }
        public void Update()
        {
            AnimatedGoomba.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 loc, Vector2 cameraLoc)
        {
            AnimatedGoomba.Draw(spriteBatch, loc, cameraLoc, FacingRight);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            AnimatedGoomba.Draw(spriteBatch, location, cameraLoc, FacingRight);
        }

        public Rectangle returnCollisionRectangle()
        {
            return AnimatedGoomba.returnCollisionRectangle();
        }
    }
}
