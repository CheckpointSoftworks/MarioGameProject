using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint2
{
    public class ItemSpriteTextureStorage
    {
        private static Texture2D oneUpMushroomSpriteSheet;
        private static Texture2D superMushroomSpriteSheet;
        private static Texture2D fireFlowerSpriteSheet;
        private static Texture2D superStarSpriteSheet;

        public static void Load(ContentManager content, GraphicsDevice device)
        {
            oneUpMushroomSpriteSheet = content.Load<Texture2D>("OneUpMushroom");
            superMushroomSpriteSheet = content.Load<Texture2D>("SuperMushroom");
            fireFlowerSpriteSheet = content.Load<Texture2D>("FireFlower");
            superStarSpriteSheet = content.Load<Texture2D>("SuperStar");
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
    }
}
