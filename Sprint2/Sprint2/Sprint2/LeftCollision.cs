using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class LeftCollision: ICollision
    {
        public ICollision.CollisionSide sideOfCollision {get;set;}

        public LeftCollision()
        {
            sideOfCollision = ICollision.CollisionSide.Left;
        }

        public ICollision.CollisionSide reutrnCollisionSide()
        {
            return sideOfCollision;
        }
    }
}
