using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class FireballCommand:ICommand
    {
        private Game1 game;
        private bool facingRight;
        public FireballCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            facingRight = ((Mario)game.mario).FacingRight;
            if (((Mario)game.mario).CanFire && game.fireBallCount>0)
            {
                Vector2 marioLoc = game.mario.returnLocation();
                game.levelStore.projectileList.Add(new Fireball((int)marioLoc.X + 3, (int)marioLoc.Y + 8, facingRight, ((Mario)game.mario), ((Mario)game.mario).CurrentGroundSpeed()));
                game.fireBallCount--;
                ((Mario)game.mario).CanFire = false;
            }
        }
    }
}
