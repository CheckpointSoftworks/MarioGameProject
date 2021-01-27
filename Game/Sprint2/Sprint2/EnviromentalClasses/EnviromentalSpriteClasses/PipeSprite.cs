using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class PipeSprite : ISprite
    {
        private Texture2D pipeSpriteSheet;
        private Vector2 location;
        private AnimatedSprite pipeSprite;
        private Rectangle collisionRectangle;
        public PipeSprite(Vector2 location)
        {
            pipeSpriteSheet = MiscGameObjectTextureStorage.CreatePipeSprite();
            this.location = location;
            pipeSprite = new AnimatedSprite(pipeSpriteSheet, UtilityClass.one, UtilityClass.one, location, UtilityClass.one);
            collisionRectangle = pipeSprite.returnCollisionRectangle();
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            pipeSprite.Draw(spriteBatch, location, cameraLoc, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
