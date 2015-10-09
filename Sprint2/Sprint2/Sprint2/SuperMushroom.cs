using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class SuperMushroom : IItemObjects
    {
        private ISprite superMushroomSprite;
        private ItemType type;
        private Rectangle collisionRectangle;

        public SuperMushroom(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            superMushroomSprite = new SuperMushroomSprite(location);
            type = ItemType.SuperMushroom;
            collisionRectangle = superMushroomSprite.returnCollisionRectangle();
        }
        public void Update()
        {
            superMushroomSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            superMushroomSprite.Draw(spriteBatch);
        }
        public ItemType returnItemType()
        {
            return type;
        }
        public void setCollisionRectangle(Rectangle collisionRectangle)
        {
            this.collisionRectangle = collisionRectangle;
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }

    }
}
