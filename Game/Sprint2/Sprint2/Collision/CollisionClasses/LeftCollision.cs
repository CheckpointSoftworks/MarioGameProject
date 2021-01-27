using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class LeftCollision: ICollision
    {
        public CollisionSide sideOfCollision {get;set;}

        public LeftCollision()
        {
            sideOfCollision = CollisionSide.Left;
        }

        public CollisionSide returnCollisionSide()
        {
            return sideOfCollision;
        }
    }
}
