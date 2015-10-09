using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class Koopa: IGameObject
    {
        private ISprite koopaSprite;
        
        public Koopa(Vector2 location)
        {
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
    }
}
