using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class CollisionDetector
    {
        private ICollision side;
        public CollisionDetector()
        {
            side = new NoneCollision();
        }

        public ICollision getCollision(Rectangle firstObjectRectangle, Rectangle secondObjectRectangle)
        {
            Rectangle intersectionRectange = Rectangle.Intersect(firstObjectRectangle, secondObjectRectangle);
            int intersectionRectangleWidth = intersectionRectange.Width;
            int intersectionRectangleHeight = intersectionRectange.Height;

            if (intersectionRectangleHeight == 0 && intersectionRectangleWidth == 0)
            {
                side = new NoneCollision();
            }
            else if (intersectionRectangleHeight > intersectionRectangleWidth)
            {
                side = chooseRightOrLeft(firstObjectRectangle, secondObjectRectangle);
            }
            else if (intersectionRectangleHeight < intersectionRectangleWidth)
            {
                side = chooseTopOrBottom(firstObjectRectangle, secondObjectRectangle);
            }
            return side;
        }

        private static ICollision chooseRightOrLeft(Rectangle firstObjectRectangle, Rectangle secondObjectRectangle)
        {
            ICollision collisionSide = new LeftCollision();
            int firstObjectXCoordinate = firstObjectRectangle.X;
            int secondObjectXCoordinate = secondObjectRectangle.X;

            if ((firstObjectXCoordinate - secondObjectXCoordinate) > 0)
            {
                collisionSide = new RightCollision();
            }

            return collisionSide;
        }
        private static ICollision chooseTopOrBottom(Rectangle firstObjectRectangle, Rectangle secondObjectRectangle)
        {
            ICollision collisionSide = new TopCollision();
            int firstObjectYCoordinate = firstObjectRectangle.Y;
            int secondObjectYCoordinate = secondObjectRectangle.Y;

            if ((firstObjectYCoordinate - secondObjectYCoordinate) > 0)
            {
                collisionSide = new BottomCollision();
            }


            return collisionSide;
        }
    }
}
