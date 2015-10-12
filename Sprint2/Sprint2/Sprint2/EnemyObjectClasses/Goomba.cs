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
        private ISprite goombaSprite;
        private Vector2 location;

        public Goomba(int locX, int locY)
        {
            location = new Vector2(locX, locY);
            goombaSprite = EnemySpriteFactory.CreateGoombaSprite(location);
        }
        public void Update()
        {
            goombaSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            goombaSprite.Draw(spriteBatch);
        }

        public Rectangle returnCollisionRectangle()
        {
            return goombaSprite.returnCollisionRectangle();
        }

        public void TakeDamage()
        {
            goombaSprite = EnemySpriteFactory.CreateGoombaDamangedSprite(location);
        }
    }
}
