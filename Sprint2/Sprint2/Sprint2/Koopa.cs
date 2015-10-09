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

        public Koopa(int locX, int locY)
        {
            Vector2 location = new Vector2(locX, locY);
            koopaSprite = EnemySpriteFactory.CreateGreenKoopaSprite(location);
        }
        public void Update()
        {
            koopaSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            koopaSprite.Draw(spriteBatch);
        }

        public Rectangle returnCollisionRectangle()
        {
            return koopaSprite.returnCollisionRectangle();
        }
    }
}
