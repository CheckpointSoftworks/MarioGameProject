using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KrisWengersSprint0
{
    public interface IPlayerState
    {
        void Still();
        void Running();
        void ChangeDirection();
        void Jump();
        void ShootFireball();
        void Duck();
        void Dying();


    }
}
