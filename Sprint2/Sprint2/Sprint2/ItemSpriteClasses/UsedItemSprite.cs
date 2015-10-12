using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class UsedItemSprite:ISprite
    {
        private Texture2D usedItemSprite;
        private Vector2 location;
        private Rectangle collisionRectangle;
        private int spriteSheetSpriteSize = 16;
        public UsedItemSprite(Vector2 location)
        {
            usedItemSprite = ItemSpriteTextureStorage.CreateUsedItemSprite();
            this.location = location;
            collisionRectangle = new Rectangle(0,0,0,0);
        }
        public void Update()
        {
            //No update needed for ground blocks
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(spriteSheetSpriteSize*0, 0, spriteSheetSpriteSize, spriteSheetSpriteSize);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, spriteSheetSpriteSize, spriteSheetSpriteSize);
            
            spriteBatch.Begin();
            spriteBatch.Draw(usedItemSprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
