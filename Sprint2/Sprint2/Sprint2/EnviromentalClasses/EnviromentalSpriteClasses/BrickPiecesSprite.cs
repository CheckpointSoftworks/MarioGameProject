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
        private int spriteSheetSpriteSize = 16;
        private int raiseAndFall;
        private bool moveLeftOrRight;

        public BrickPiecesSprite(Vector2 location,bool moveDirection)
        {
            brickPiecesSpriteSheet = MiscGameObjectTextureStorage.CreateBrickPiecesSprite();
            this.location = location;
            frame = 0;
            raiseAndFall = 70;
            moveLeftOrRight = moveDirection;
            collisionRectangle = new Rectangle(0,0,0,0);
        }
        public void Update()
        {
            if (raiseAndFall > 60)
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
            else if (raiseAndFall > 0)
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
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            Rectangle sourceRectangle = sourceRectangle = new Rectangle((spriteSheetSpriteSize*frame), 0, (spriteSheetSpriteSize), (spriteSheetSpriteSize));
            Rectangle destinationRectangle = new Rectangle((int)location.X - (int)cameraLoc.X, (int)location.Y - (int)cameraLoc.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);

            spriteBatch.Draw(brickPiecesSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
