using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class QuestionBlockSprite : ISprite
    {
        private Texture2D questionBlockSpriteSheet;
        private bool used;
        private Vector2 location;
        private Rectangle collisionRectangle;
        private int frame;
        private int spriteSheetSpriteSize;
        private int totalFrames;
        private int bounceTimer;
        private bool bounce;
        private int minY;

        public QuestionBlockSprite(Vector2 location)
        {
            questionBlockSpriteSheet = BlockSpriteTextureStorage.CreateQuestionBlockSprite();
            this.location = location;
            frame = UtilityClass.zero;
            used = false;
            bounce = false;
            totalFrames=UtilityClass.one;
            bounceTimer = UtilityClass.BlockBounceTimer;
            spriteSheetSpriteSize = questionBlockSpriteSheet.Width / UtilityClass.two;
            minY = (int)location.Y;
            collisionRectangle = new Rectangle((int)location.X, (int)location.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);
        }

        public void Update()
        {
            if (used && frame < totalFrames)
            {
                frame++;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            bounceTheBlock();
            Rectangle sourceRectangle = new Rectangle((spriteSheetSpriteSize * frame), UtilityClass.zero, (spriteSheetSpriteSize), (spriteSheetSpriteSize));
            Rectangle destinationRectangle = new Rectangle((int)location.X - (int)cameraLoc.X, (int)location.Y - (int)cameraLoc.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);

            spriteBatch.Begin();
            spriteBatch.Draw(questionBlockSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }

        public void bounceSprite()
        {
            bounce = true;
        }

        public void switchToUsed()
        {
            used = true;
        }

        private void bounceTheBlock()
        {
            if (bounceTimer > (UtilityClass.BlockBounceTimer/UtilityClass.two) && bounce)
            {
                int newY = (int)location.Y;
                newY--;
                location = new Vector2(location.X, newY);
                bounceTimer--;
            }
            else if (bounce && bounceTimer > 0)
            {
                int newY = (int)location.Y;
                newY++;
                location = new Vector2(location.X, newY);
                bounceTimer--;
            }
            if (bounceTimer == 0)
            {
                used = true;
                location = new Vector2(location.X, minY);
            }
        }
    }
}
