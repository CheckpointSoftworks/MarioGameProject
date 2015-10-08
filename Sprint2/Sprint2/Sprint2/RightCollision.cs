using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class RightCollision : ICollision
    {
        public ICollision.CollisionSide sideOfCollision {get;set;}

        public RightCollision()
        {
            sideOfCollision = ICollision.CollisionSide.Right;
        }

        public ICollision.CollisionSide reutrnCollisionSide()
        {
            return sideOfCollision;
        }
    }
}
