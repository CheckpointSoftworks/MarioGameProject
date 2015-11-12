using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class StaticCoinSprite : ISprite
    {
        private Texture2D spriteSheet;
        private AnimatedSprite sprite;
        private Vector2 location { get; set; }
        public StaticCoinSprite(Vector2 location)
        {
            spriteSheet = ItemSpriteTextureStorage.CreateStaticCoinSprite();
            this.location = location;
            sprite = new AnimatedSprite(spriteSheet, UtilityClass.one, UtilityClass.one, location, UtilityClass.one);
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
