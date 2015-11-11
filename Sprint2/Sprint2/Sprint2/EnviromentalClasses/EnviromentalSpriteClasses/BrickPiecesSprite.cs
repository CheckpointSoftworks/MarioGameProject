using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BrickPiecesSprite:ISprite
    {
        private Texture2D brickPiecesSpriteSheet;
        private Vector2 location;
        private Rectangle collisionRectangle;
        private int frame;
        private int totalFrames;
        private int spriteSheetSpriteSize;
        private int raiseAndFall;
        private bool moveLeftOrRight;

        public BrickPiecesSprite(Vector2 location,bool moveDirection)
        {
            brickPiecesSpriteSheet = MiscGameObjectTextureStorage.CreateBrickPiecesSprite();
            this.location = location;
            frame = UtilityClass.zero;
            totalFrames = UtilityClass.one;
            spriteSheetSpriteSize = brickPiecesSpriteSheet.Width / UtilityClass.two;
            raiseAndFall = UtilityClass.brickPiecesRise;
            moveLeftOrRight = moveDirection;
            collisionRectangle = new Rectangle(UtilityClass.zero,UtilityClass.zero,UtilityClass.zero,UtilityClass.zero);
        }
        public void Update()
        {
            if (raiseAndFall > UtilityClass.brickPiecesRise)
            {
                int newY = (int)location.Y;
                newY--;
                int newX = (int)location.X;
                if (moveLeftOrRight)
                {
                    newX--;
                }
                else
                {
                    newX++;
                }
                location = new Vector2(newX, newY);
                raiseAndFall--;
            }
            else if (raiseAndFall > UtilityClass.zero)
            {
                int newY = (int)location.Y;
                newY++;
                location = new Vector2(location.X, newY);
                raiseAndFall--;
            }
            else
            {
                brickPiecesSpriteSheet = ItemSpriteTextureStorage.CreateUsedItemSprite();
            }
            if (frame == totalFrames)
            {
                frame = UtilityClass.zero;
            }
            else
            {
                frame++;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            Rectangle sourceRectangle = sourceRectangle = new Rectangle((spriteSheetSpriteSize*frame), UtilityClass.zero, (spriteSheetSpriteSize), (spriteSheetSpriteSize));
            Rectangle destinationRectangle = new Rectangle((int)location.X - (int)cameraLoc.X, (int)location.Y - (int)cameraLoc.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);

            spriteBatch.Begin();
            spriteBatch.Draw(brickPiecesSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
