using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BlueGroundBlockSprite : ISprite
    {
        private Texture2D groundBlockSpriteSheet;
        private Vector2 location;
        private Rectangle collisionRectangle;
        private int spriteSheetSpriteSize = 16;

        public BlueGroundBlockSprite(Vector2 location)
        {
            groundBlockSpriteSheet = BlockSpriteTextureStorage.CreateBlueGroundBlockSprite();
            this.location = location;
            collisionRectangle = new Rectangle((int)location.X, (int)location.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            Rectangle sourceRectangle = new Rectangle(spriteSheetSpriteSize * UtilityClass.zero, UtilityClass.zero, spriteSheetSpriteSize, spriteSheetSpriteSize);
            Rectangle destinationRectangle = new Rectangle((int)location.X - (int)cameraLoc.X, (int)location.Y - (int)cameraLoc.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);

            spriteBatch.Draw(groundBlockSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
