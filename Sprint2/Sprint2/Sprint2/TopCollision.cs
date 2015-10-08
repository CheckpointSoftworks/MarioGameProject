using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class TopCollision:ICollision
    {
        public ICollision.CollisionSide sideOfCollision {get;set;}

        public TopCollision()
        {
            sideOfCollision = ICollision.CollisionSide.Top;
        }

        public ICollision.CollisionSide reutrnCollisionSide()
        {
            return sideOfCollision;
        }
    }
}
