using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class BottomCollision : ICollision
    {
        public CollisionSide sideOfCollision {get;set;}

        public BottomCollision()
        {
            sideOfCollision = CollisionSide.Bottom;
        }

        public CollisionSide returnCollisionSide()
        {
            return sideOfCollision;
        }
    }
}
