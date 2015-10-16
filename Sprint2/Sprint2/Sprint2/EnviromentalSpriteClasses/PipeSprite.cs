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
            pipeSprite = new AnimatedSprite(pipeSpriteSheet, 1, 1, location, 1);
            collisionRectangle = pipeSprite.returnCollisionRectangle();
        }
        public void Update()
        {
            //No update needed. Only one frame of animation.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pipeSprite.Draw(spriteBatch, location, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
