using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class GoombaHealthy: IEnemyState
    {
        private Goomba goomba;
        AnimatedSprite sprite;
        public GoombaHealthy(Goomba goomba)
        {
            this.goomba = goomba;
            sprite = new AnimatedSprite(EnemySpriteFactory.CreateGoombaSprite(), 1, 2, goomba.returnLocation(), 4);
        }

        public void Update()
        {
            sprite.Update();
        }

        public void TakeDamage()
        {
            goomba.State = new GoombaDamaged(goomba);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, goomba.returnLocation(), goomba.DirectionLeft);
        }
        public Rectangle returnStateCollisionRectangle()
        {           
            return sprite.returnCollisionRectangle();
        }
    }
}
