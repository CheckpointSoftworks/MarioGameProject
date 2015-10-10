using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BoxCoin : IItemObjects
    {
        private ISprite boxCoinSprite;
        private ItemType type;
        private Rectangle collisonRectangle;
        private bool testForCollision;

        public BoxCoin(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            boxCoinSprite = new BoxCoinSprite(location);
            type = ItemType.Coin;
            collisonRectangle = boxCoinSprite.returnCollisionRectangle();
            testForCollision = true;
        }
        public void Update()
        {
            boxCoinSprite.Update();
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
            boxCoinSprite.Draw(spriteBatch);
        }

        public void setCollisionRectangle(Rectangle collisionRectangle)
        {
            this.collisonRectangle = collisionRectangle;
            testForCollision = false;
        }

        public bool checkForCollisionTestFlag()
        {
            return testForCollision;
        }
    }
}
