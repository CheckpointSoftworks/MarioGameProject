using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public interface ICollision
    {
        public enum CollisionSide { Top, Bottom, Left, Right, None };

        public CollisionSide returnCollisionSide();
    }
}
