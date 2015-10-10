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

        public OneUpMushroom(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
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
