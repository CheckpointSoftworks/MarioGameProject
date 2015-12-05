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
        private static Texture2D iceFlowerSpriteSheet;
        private static Texture2D superStarSpriteSheet;
        private static Texture2D boxCoinSpriteSheet;
        private static Texture2D usedItemSpriteSheet;
        private static Texture2D staticcoinSpriteSheet;
        public static void Load(ContentManager content)
        {
            oneUpMushroomSpriteSheet = content.Load<Texture2D>(UtilityClass.oneUpSpriteSheet);
            superMushroomSpriteSheet = content.Load<Texture2D>(UtilityClass.supMushroomSpriteSheet);
            fireFlowerSpriteSheet = content.Load<Texture2D>(UtilityClass.fireFlowerSpriteSheet);
            iceFlowerSpriteSheet = content.Load<Texture2D>(UtilityClass.iceFlowerSpriteSheet);
            superStarSpriteSheet = content.Load<Texture2D>(UtilityClass.starSpriteSheet);
            boxCoinSpriteSheet = content.Load<Texture2D>(UtilityClass.boxCoinSpriteSheet);
            usedItemSpriteSheet = content.Load<Texture2D>(UtilityClass.usedItemSpriteSheet);
            staticcoinSpriteSheet = content.Load<Texture2D>(UtilityClass.staticCoinSpriteSheet);
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
        public static Texture2D CreateIceFlowerSprite()
        {
            return iceFlowerSpriteSheet;
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
        public static Texture2D CreateStaticCoinSprite()
        {
            return staticcoinSpriteSheet;
        }
    }
}
