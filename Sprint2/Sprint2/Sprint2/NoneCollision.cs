using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class NoneCollision:ICollision
    {
        public ICollision.CollisionSide sideOfCollision {get;set;}

        public NoneCollision()
        {
            sideOfCollision = ICollision.CollisionSide.None;
        }

        public ICollision.CollisionSide reutrnCollisionSide()
        {
            return sideOfCollision;
        }
    }
}
