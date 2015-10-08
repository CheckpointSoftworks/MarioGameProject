using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class BottomCollision : ICollision
    {
        public ICollision.CollisionSide sideOfCollision {get;set;}

        public BottomCollision()
        {
            sideOfCollision = ICollision.CollisionSide.Bottom;
        }

        public ICollision.CollisionSide reutrnCollisionSide()
        {
            return sideOfCollision;
        }
    }
}
