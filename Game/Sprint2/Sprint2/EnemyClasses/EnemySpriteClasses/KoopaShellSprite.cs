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
            AnimatedKoopa = new AnimatedSprite(koopaSpritesheet, UtilityClass.one, UtilityClass.one, location, UtilityClass.enemyTotalFramesAndMarioFlagpoleTotalFrames);
        }
        public void Update()
        {

            AnimatedKoopa.Update();

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            AnimatedKoopa.Draw(spriteBatch, location, cameraLoc, FacingRight);

        }

        public Rectangle returnCollisionRectangle()
        {
            return AnimatedKoopa.returnCollisionRectangle();
        }

    }
}
