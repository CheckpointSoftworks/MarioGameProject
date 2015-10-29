using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class ItemEnvriomentalCollisionHandler
    {
        public ItemEnvriomentalCollisionHandler()
        {

        }
        public void handleCollision(IItemObjects item, IEnviromental enviro, ICollision side)
        {
            if (!(side.returnCollisionSide().Equals(CollisionSide.None)))
            {
                handleItemMovement(item, enviro, side);
            }
        }

        private void handleItemMovement(IItemObjects item, IEnviromental enviro, ICollision side)
        {
            Rectangle blockRectangle = enviro.returnCollisionRectangle();
            Rectangle itemRectangle = item.returnCollisionRectangle();
            Rectangle intersectionRectangle = Rectangle.Intersect(itemRectangle, blockRectangle);
            Vector2 itemLocation = item.returnLocation();
            int locationDiffToChange = 0;

            if (side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newItemX = (int)itemLocation.X - locationDiffToChange;
                item.updateLocation(new Vector2((newItemX), itemLocation.Y));
                item.RigidBody().RightCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                locationDiffToChange = intersectionRectangle.Width;
                int newItemX = (int)itemLocation.X + locationDiffToChange;
                item.updateLocation(new Vector2((newItemX), itemLocation.Y));
                item.RigidBody().LeftCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newItemY = (int)itemLocation.Y - locationDiffToChange;
                item.updateLocation(new Vector2(itemLocation.X, newItemY));
                item.RigidBody().BottomCollision();
            }
            else if (side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                locationDiffToChange = intersectionRectangle.Height;
                int newItemY = (int)itemLocation.Y + locationDiffToChange;
                item.updateLocation(new Vector2(itemLocation.X, newItemY));
                item.RigidBody().TopCollision();
            }
        }
    }
}
