﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class GroundBlock : IGameObject
    {
        private ISprite groundBlockSprite;
        public GroundBlock(Texture2D groundBlockSpriteSheet)
        {
            groundBlockSprite = new GroundBlockSprite();
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
