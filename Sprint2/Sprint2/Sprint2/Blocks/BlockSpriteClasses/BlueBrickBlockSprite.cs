using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BlueBrickBlockSprite:ISprite
    {
        private Texture2D brickBlockSpriteSheet;
        private Vector2 location;
        private bool smashed;
        private Rectangle collisionRectangle;
        private int frame;
        private int spriteSheetSpriteSize = UtilityClass.sixteen;
        private int totalFrames;

        public BlueBrickBlockSprite(Vector2 location)
        {
            brickBlockSpriteSheet = BlockSpriteTextureStorage.CreateBlueBrickBlockSprite();
            this.location = location;
            frame = 0;
            totalFrames = 1;
            smashed = false;
            collisionRectangle = new Rectangle((int)location.X, (int)location.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);
        }

        public void Update()
        {
            if (smashed && frame < totalFrames)
            {
                frame++;
                collisionRectangle = new Rectangle(UtilityClass.zero, UtilityClass.zero, UtilityClass.zero, UtilityClass.zero);
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            Rectangle sourceRectangle = sourceRectangle = new Rectangle((spriteSheetSpriteSize * frame), UtilityClass.zero, (spriteSheetSpriteSize), (spriteSheetSpriteSize));
            Rectangle destinationRectangle = new Rectangle((int)location.X - (int)cameraLoc.X, (int)location.Y - (int)cameraLoc.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);
         
            spriteBatch.Draw(brickBlockSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
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
