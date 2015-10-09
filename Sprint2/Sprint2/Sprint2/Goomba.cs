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

        public Goomba(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
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
    }
}
