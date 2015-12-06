using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class IceballCommand : ICommand
    {
        private Game1 game;
        private bool facingRight;
        public IceballCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            facingRight = ((Mario)game.mario).FacingRight;
            if (((Mario)game.mario).CanIce && game.iceBallCount > 0)
            {
                Vector2 marioLoc = game.mario.GetLocation();
                game.levelStore.projectileList.Add(new Iceball((int)marioLoc.X + UtilityClass.iceballSpawnXOffset, (int)marioLoc.Y + UtilityClass.iceballSpawnYOffset, ((Mario)game.mario).CurrentGroundSpeed(), facingRight, game.mario));
                game.iceBallCount--;
                ((Mario)game.mario).CanIce = false;
                ((Mario)game.mario).State.ShootIceball();
            }
        }
    }
}
