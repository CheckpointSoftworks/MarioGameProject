using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class OneUpMushroom : IItemObjects
    {
        private ISprite oneUpMushroomSprite;
        private ItemType type;
        private Rectangle collisionRectangle;
        private bool testForCollision;
        private Vector2 location;

        public OneUpMushroom(int locX, int locY)
        {
            location = new Vector2(locX, locY);
            oneUpMushroomSprite = new OneUpMushroomSprite(location);
            type = ItemType.OneUpMushroom;
            collisionRectangle = oneUpMushroomSprite.returnCollisionRectangle();
            testForCollision=true;
        }
        public void Update()
        {
            oneUpMushroomSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            oneUpMushroomSprite.Draw(spriteBatch);
        }

        public void setCollisionRectangle(Rectangle collisionRectangle)
        {
            this.collisionRectangle = collisionRectangle;
            testForCollision=false;
            oneUpMushroomSprite = new UsedItemSprite(location);
        }
        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
        public ItemType returnItemType()
        {
            return type;
        }
        public bool checkForCollisionTestFlag()
        {
            return testForCollision;
        }
    }
}
