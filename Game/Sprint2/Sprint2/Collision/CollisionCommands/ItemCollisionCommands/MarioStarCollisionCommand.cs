using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class MarioStarCollisionCommand:ICommand
    {
        private IPlayer mario;
        private IItemObjects star;
        public MarioStarCollisionCommand(IPlayer mario,IItemObjects star)
        {
            this.mario = mario;
            this.star = star;
        }
        public void Execute()
        {
            star.setCollisionRectangle(new Rectangle(UtilityClass.zero, UtilityClass.zero, UtilityClass.zero, UtilityClass.zero));
            ((Mario)mario).Star = true;
            ((Mario)mario).stats.GotSuperStar();

        }
    }
}
