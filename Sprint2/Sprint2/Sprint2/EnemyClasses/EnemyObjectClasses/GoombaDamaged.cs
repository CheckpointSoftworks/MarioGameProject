using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class GoombaDamaged : IEnemyState
    {
        private Goomba goomba;
        AnimatedSprite sprite;
        public GoombaDamaged(Goomba goomba)
        {
            this.goomba = goomba;
            sprite = new AnimatedSprite(EnemySpriteFactory.CreateGoombaDamangedSprite(), 1, 1, goomba.returnLocation(), 4);
        }

        public void Update()
        {
            sprite.Update();
        }

        public void TakeDamage()
        {
            //
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, goomba.returnLocation(), true);
        }
        public Rectangle returnStateCollisionRectangle()
        {
            return new Rectangle(0, 0, 0, 0);
        }
    }
}