using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class RightCollision : ICollision
    {
        public CollisionSide sideOfCollision {get;set;}

        public RightCollision()
        {
            sideOfCollision = CollisionSide.Right;
        }

        public CollisionSide returnCollisionSide()
        {
            return sideOfCollision;
        }
    }
}
