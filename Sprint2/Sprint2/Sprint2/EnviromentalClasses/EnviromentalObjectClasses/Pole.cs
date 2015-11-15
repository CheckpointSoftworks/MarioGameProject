using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class Pole : IPole
    {
        private IPoleSprite poleSprite;
        private Vector2 location;
        public Pole()
        {
            location = new Vector2(UtilityClass.poleLocationX, UtilityClass.poleLocationY);
            poleSprite = new PoleSprite(location);
        }
        public void Update()
        {
            poleSprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            poleSprite.Draw(spriteBatch, cameraLoc);
        }
    }
}
