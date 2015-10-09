using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class TopCollision:ICollision
    {
        private CollisionSide sideOfCollision;

        public TopCollision()
        {
            sideOfCollision = CollisionSide.Top;
        }

        public CollisionSide returnCollisionSide()
        {
            return sideOfCollision;
        }
    }
}
