using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class KoopaHealthy : IEnemyState
    {
        private Koopa koopa;
        AnimatedSprite sprite;
        public KoopaHealthy(Koopa Koopa)
        {
            this.koopa = Koopa;
            sprite = new AnimatedSprite(EnemySpriteFactory.CreateKoopaSprite(), 1, 2, koopa.returnLocation(), 4);
        }

        public void Update()
        {
            sprite.Update();
        }

        public void TakeDamage()
        {
            koopa.State = new KoopaDamaged(koopa);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, koopa.returnLocation(), true);
        }
        public Rectangle returnStateCollisionRectangle()
        {
            return sprite.returnCollisionRectangle();
        }
    }
}
