using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class SuperStar : IItemObjects
    {
        private ISprite superStarSprite;
        private ItemType type;
        private Rectangle collisionRectangle;

        public SuperStar(int locX,int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            superStarSprite = new SuperStarSprite(location);
            type = ItemType.Star;
            collisionRectangle = superStarSprite.returnCollisionRectangle();
        }
        public void Update()
        {
            superStarSprite.Update();
        }
       
        public void Draw(SpriteBatch spriteBatch)
        {
            superStarSprite.Draw(spriteBatch);
        }
        public ItemType returnItemType()
        {
            return type;
        }
        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }

        public void setCollisionRectangle(Rectangle collisionRectangle)
        {
            this.collisionRectangle = collisionRectangle;
        }
    }
}
