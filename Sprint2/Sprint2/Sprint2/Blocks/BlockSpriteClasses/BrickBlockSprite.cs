using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BrickBlockSprite : ISprite
    {
        private Texture2D brickBlockSpriteSheet;
        private Vector2 location;
        private bool smashed;
        private Rectangle collisionRectangle;
        private int frame;
        private int spriteSheetSpriteSize;
        private int totalFrames;

        public BrickBlockSprite(Vector2 location)
        {
            brickBlockSpriteSheet = BlockSpriteTextureStorage.CreateBrickBlockSprite();
            this.location = location;
            frame = UtilityClass.zero;
            totalFrames = UtilityClass.one;
            smashed = false;
            spriteSheetSpriteSize = brickBlockSpriteSheet.Width / UtilityClass.two;
            collisionRectangle = new Rectangle((int)location.X, (int)location.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);
        }
        public void Update()
        {
            if (smashed&&frame<totalFrames)
            {
                frame++;
                collisionRectangle = new Rectangle(0, 0, 0, 0);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            Rectangle sourceRectangle = sourceRectangle = new Rectangle((spriteSheetSpriteSize*frame), 0, (spriteSheetSpriteSize), (spriteSheetSpriteSize));
            Rectangle destinationRectangle = new Rectangle((int)location.X - (int)cameraLoc.X, (int)location.Y - (int)cameraLoc.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);

            spriteBatch.Begin();
            spriteBatch.Draw(brickBlockSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }

        public void hasSmashed()
        {
            smashed = true;
        }
    }
}
