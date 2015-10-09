using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class Goomba: IGameObject
    {
        private ISprite goombaSprite;
        
        public Goomba(Vector2 location)
        {
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
    }
}
