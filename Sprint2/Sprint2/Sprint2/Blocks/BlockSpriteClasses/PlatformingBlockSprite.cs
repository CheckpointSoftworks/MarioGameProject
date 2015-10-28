using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class PlatformingBlockSprite : ISprite
    {
        private Texture2D platformingBlockSpriteSheet;
        private Vector2 location; 
        private Rectangle collisionRectangle;
        private int spriteSheetSpriteSize = 16;

        public PlatformingBlockSprite(Vector2 location)
        {
            platformingBlockSpriteSheet = BlockSpriteTextureStorage.CreatePlatformingBlockSprite();
            this.location = location;
            collisionRectangle = new Rectangle((int)location.X, (int)location.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);
        }

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            Rectangle sourceRectangle = new Rectangle(spriteSheetSpriteSize * 0, 0, spriteSheetSpriteSize, spriteSheetSpriteSize);
            Rectangle destinationRectangle = new Rectangle((int)location.X - (int)cameraLoc.X, (int)location.Y - (int)cameraLoc.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);

            spriteBatch.Begin();
            spriteBatch.Draw(platformingBlockSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
            
        }
        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
