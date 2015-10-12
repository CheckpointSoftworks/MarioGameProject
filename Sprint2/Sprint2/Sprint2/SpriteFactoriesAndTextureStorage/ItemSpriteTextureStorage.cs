using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint2
{
    public static class ItemSpriteTextureStorage
    {
        private static Texture2D oneUpMushroomSpriteSheet;
        private static Texture2D superMushroomSpriteSheet;
        private static Texture2D fireFlowerSpriteSheet;
        private static Texture2D superStarSpriteSheet;
        private static Texture2D boxCoinSpriteSheet;
        private static Texture2D usedItemSpriteSheet;

        public static void Load(ContentManager content)
        {
            oneUpMushroomSpriteSheet = content.Load<Texture2D>("OneUpMushroom");
            superMushroomSpriteSheet = content.Load<Texture2D>("SuperMushroom");
            fireFlowerSpriteSheet = content.Load<Texture2D>("FireFlower");
            superStarSpriteSheet = content.Load<Texture2D>("SuperStar");
            boxCoinSpriteSheet = content.Load<Texture2D>("BoxCoin");
            usedItemSpriteSheet = content.Load<Texture2D>("UsedItemSprite");
        }

        public static Texture2D CreateOneUpMushroomSprite()
        {
            return oneUpMushroomSpriteSheet;
        }
        public static Texture2D CreateSuperMushroomSprite()
        {
            return superMushroomSpriteSheet;
        }
        public static Texture2D CreateFireFlowerSprite()
        {
            return fireFlowerSpriteSheet;
        }
        public static Texture2D CreateSuperStarSprite()
        {
            return superStarSpriteSheet;
        }
        public static Texture2D CreateBoxCoinSprite()
        {
            return boxCoinSpriteSheet;
        }
        public static Texture2D CreateUsedItemSprite()
        {
            return usedItemSpriteSheet;
        }        
    }
}
