using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class HiddenBlockSprite : ISprite
    {
        private Texture2D hiddenBlockSpriteSheet;
        private bool used;
        private Vector2 location; 
        private Rectangle collisionRectangle;
        private int frame;
        private int spriteSheetSpriteSize;
        private int totalFrames;


        public HiddenBlockSprite(Vector2 location)
        {
            hiddenBlockSpriteSheet = BlockSpriteTextureStorage.CreateHiddenBlockSprite();
            this.location = location;
            frame = UtilityClass.zero;
            used = false;
            totalFrames = UtilityClass.one;
            spriteSheetSpriteSize = hiddenBlockSpriteSheet.Width / UtilityClass.two;
            collisionRectangle = new Rectangle((int)location.X, (int)location.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);
        }

        public void Update()
        {
            if (used&&frame<totalFrames)
            {
                frame++;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            Rectangle sourceRectangle = sourceRectangle = new Rectangle((spriteSheetSpriteSize * frame), UtilityClass.zero, (spriteSheetSpriteSize), (spriteSheetSpriteSize));
            Rectangle destinationRectangle = new Rectangle((int)location.X - (int)cameraLoc.X, (int)location.Y - (int)cameraLoc.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);

            
            spriteBatch.Draw(hiddenBlockSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
        public void usedHiddenBlock()
        {
            used = true;
        }
    }
}
