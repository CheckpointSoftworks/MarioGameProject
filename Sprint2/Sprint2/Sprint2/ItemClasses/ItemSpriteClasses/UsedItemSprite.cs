﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class UsedItemSprite:ISprite
    {
        private Texture2D usedItemSpriteSheet;
        private AnimatedSprite usedItemSprite;
        private Rectangle collisionRectangle;
        private Vector2 location;
        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }
        public UsedItemSprite(Vector2 location)
        {
            usedItemSpriteSheet = ItemSpriteTextureStorage.CreateUsedItemSprite();
            this.location = location;
            usedItemSprite = new AnimatedSprite(usedItemSpriteSheet, 1, 1, location, 1);
            collisionRectangle = new Rectangle(0,0,0,0);
        }
        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            usedItemSprite.Draw(spriteBatch, location, cameraLoc, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
