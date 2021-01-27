using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class PoleSprite : IPoleSprite
    {
        private AnimatedSprite poleSprite;
        private Texture2D poleSpriteSheet;
        private Vector2 location;
        public PoleSprite(Vector2 location)
        {
            this.location = location;
            poleSpriteSheet = MiscGameObjectTextureStorage.CreatePoleSprite();
            poleSprite = new AnimatedSprite(poleSpriteSheet, 1, 1, location, 1);
        }

        public void Update()
        {
            poleSprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            poleSprite.Draw(spriteBatch, location, cameraLoc, true);
        }
    }
}
