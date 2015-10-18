using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class Koopa: IEnemyObject
    {
        private ISprite koopaSprite;
        private ISprite koopaDamagedSprite;
        private ISprite currentSprite;
        private Rectangle collisionRectangle;
        public Koopa(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            koopaSprite = EnemySpriteFactory.CreateGreenKoopaSprite(location);
            koopaDamagedSprite = EnemySpriteFactory.CreateGreenKoopaShellSprite(location);
            currentSprite = koopaSprite;
            collisionRectangle = currentSprite.returnCollisionRectangle();
        }
        public void Update()
        {
            koopaSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.Draw(spriteBatch);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }

        public void TakeDamage()
        {
            collisionRectangle = new Rectangle(0, 0, 0, 0);
            currentSprite = koopaDamagedSprite;
        }
    }
}
