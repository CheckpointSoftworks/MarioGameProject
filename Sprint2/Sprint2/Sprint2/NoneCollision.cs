using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class NoneCollision:ICollision
    {
        public CollisionSide sideOfCollision {get;set;}

        public NoneCollision()
        {
            sideOfCollision = CollisionSide.None;
        }

        public CollisionSide returnCollisionSide()
        {
            return sideOfCollision;
        }
    }
}
