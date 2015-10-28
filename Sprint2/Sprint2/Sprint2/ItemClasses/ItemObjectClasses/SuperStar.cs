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
        private bool testForCollision;
        private Vector2 location;

        public SuperStar(int locX,int locY)
        {
            location = new Vector2(locX, locY);
            superStarSprite = new SuperStarSprite(location);
            type = ItemType.Star;
            collisionRectangle = superStarSprite.returnCollisionRectangle();
            testForCollision=true;
        }
        public void Update()
        {
            superStarSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            superStarSprite.Draw(spriteBatch, cameraLoc);
        }
        public ItemType returnItemType()
        {
            return type;
        }
        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }

        public void setCollisionRectangle(Rectangle sentCollisionRectangle)
        {
            collisionRectangle = sentCollisionRectangle;
            testForCollision=false;
            superStarSprite = new UsedItemSprite(location);
        }
        public bool checkForCollisionTestFlag()
        {
            return testForCollision;
        }
    }
}
