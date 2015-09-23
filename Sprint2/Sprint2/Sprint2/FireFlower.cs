using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class FireFlower : IGameObject
    {
        private ISprite fireFlowerSprite;
        public FireFlower()
        {
            fireFlowerSprite = new FireFlowerSprite();
        }
        public void Update()
        {
            fireFlowerSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            fireFlowerSprite.Draw(spriteBatch);
        }
    }
}
