using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class KoopaDamaged : IEnemyState
    {
        private Koopa koopa;
        AnimatedSprite sprite;
        public KoopaDamaged(Koopa Koopa)
        {
            this.koopa = Koopa;
            sprite = new AnimatedSprite(EnemySpriteFactory.CreateKoopaDamagedSprite(), 1, 1, koopa.returnLocation(), 1);
        }

        public void Update()
        {
            sprite.Update();
        }

        public void TakeDamage()
        {
            //
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            sprite.Draw(spriteBatch, koopa.returnLocation(), cameraLoc, true);
        }
        public Rectangle returnStateCollisionRectangle()
        {
            return new Rectangle(0, 0, 0, 0);
        }
    }
}
