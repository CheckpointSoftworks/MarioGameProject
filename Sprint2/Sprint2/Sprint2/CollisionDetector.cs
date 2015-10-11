using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class CollisionDetector:ICollisionDetector
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
                //Left-Right Intersection
                side = chooseRightOrLeft(intersectionRectange, firstObjectRectangle, secondObjectRectangle);
            }
            else if (intersectionRectangleHeight < intersectionRectangleWidth)
            {
                //Top-Bottom Intersection
                side = chooseTopOrBottom(intersectionRectange, firstObjectRectangle, secondObjectRectangle);
            }
            return side;
        }

        private ICollision chooseRightOrLeft(Rectangle intersectionRectangle, Rectangle firstObjectRectangle, Rectangle secondObjectRectangle)
        {
            ICollision side = new LeftCollision();
            int firstObjectXCoordinate = firstObjectRectangle.X;
            int secondObjectXCoordinate = secondObjectRectangle.X;

            if ((firstObjectXCoordinate - secondObjectXCoordinate) > 0)
            {
                side = new RightCollision();
            }

            return side;
        }
        private ICollision chooseTopOrBottom(Rectangle intersectionRectangle, Rectangle firstObjectRectangle, Rectangle secondObjectRectangle)
        {
            ICollision side = new TopCollision();
            int firstObjectYCoordinate = firstObjectRectangle.Y;
            int secondObjectYCoordinate = secondObjectRectangle.Y;

            if ((firstObjectYCoordinate - secondObjectYCoordinate) > 0)
            {
                side = new BottomCollision();
            }


            return side;
        }
    }
}
