using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    class OneUpMushroomSprite : ISprite
    {
        private Texture2D oneUpMushroomSpriteSheet;
        private Vector2 location;
        private AnimatedSprite oneUpMushroomSprite;
        private Rectangle collisionRectangle;
        public OneUpMushroomSprite(Vector2 location)
        {
            oneUpMushroomSpriteSheet = ItemSpriteTextureStorage.CreateOneUpMushroomSprite();
            this.location = location;
            oneUpMushroomSprite = new AnimatedSprite(oneUpMushroomSpriteSheet, 1, 1, location, 1);
            collisionRectangle = oneUpMushroomSprite.returnCollisionRectangle();
        }

        public void Update()
        {
            //No update needed. Only one frame of animation.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            oneUpMushroomSprite.Draw(spriteBatch, location, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}