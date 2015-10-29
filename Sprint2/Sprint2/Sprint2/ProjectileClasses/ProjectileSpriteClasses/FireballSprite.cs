using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
        class FireballSprite : ISprite
        {
           private Texture2D spriteSheet;
        private AnimatedSprite sprite;
        private Rectangle collisionRectangle;
        private Vector2 location;
        public FireballSprite(Vector2 location)
        {
            spriteSheet = MiscGameObjectTextureStorage.CreateFireballSprite();
            this.location = location;
            sprite = new AnimatedSprite(spriteSheet, 1, 1, location, 1);
            collisionRectangle = sprite.returnCollisionRectangle();
        }

        public void Update()
        {
            sprite.Update();
        }
        public void Update(Vector2 loc)
        {
            location = loc;
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            sprite.Draw(spriteBatch, location, cameraLoc, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return sprite.returnCollisionRectangle();
        }
        }
}
