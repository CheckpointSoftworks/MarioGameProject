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
        public FireFlower(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            fireFlowerSprite = new FireFlowerSprite(location);
            type = ItemType.FireFlower;
            collisonRectangle = fireFlowerSprite.returnCollisionRectangle();
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
        }
    }
}
