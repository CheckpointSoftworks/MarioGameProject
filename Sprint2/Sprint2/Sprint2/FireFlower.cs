using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class FireFlower : IItemObjects
    {
        private ISprite fireFlowerSprite;
        private ItemType type;
        private Rectangle collisonRectangle;
        private bool testForCollision;
        private Vector2 location;

        public FireFlower(int locX, int locY)
        {
            location = new Vector2(locX, locY);
            fireFlowerSprite = new FireFlowerSprite(location);
            type = ItemType.FireFlower;
            collisonRectangle = fireFlowerSprite.returnCollisionRectangle();
            testForCollision = true;
        }
        public void Update()
        {
            fireFlowerSprite.Update();
        }
        public ItemType returnItemType()
        {
            return type;
        }
        public Rectangle returnCollisionRectangle()
        {
            return collisonRectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            fireFlowerSprite.Draw(spriteBatch);
        }

        public void setCollisionRectangle(Rectangle collisionRectangle)
        {
            this.collisonRectangle = collisionRectangle;
            testForCollision = false;
            fireFlowerSprite = new UsedItemSprite(location);
        }
        public bool checkForCollisionTestFlag()
        {
            return testForCollision;
        }
    }
}
