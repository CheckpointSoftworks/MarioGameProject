using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class Goomba: IEnemyObject
    {
        private ISprite currentSprite;
        private ISprite normalGoombaSprite;
        private ISprite damagedGoombaSprite;

        public Goomba(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            normalGoombaSprite = EnemySpriteFactory.CreateGoombaSprite(location);
            damagedGoombaSprite = EnemySpriteFactory.CreateGoombaDamangedSprite(location);
            currentSprite = normalGoombaSprite;

        }
        public void Update()
        {
            currentSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.Draw(spriteBatch);
        }

        public Rectangle returnCollisionRectangle()
        {
            return currentSprite.returnCollisionRectangle();
        }

        public void TakeDamage()
        {
            currentSprite = damagedGoombaSprite;
        }
    }
}
