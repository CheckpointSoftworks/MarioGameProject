using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint2
{
    public static class BlockSpriteTextureStorage
    {
        private static Texture2D hiddenBlockSpritesheet;
        private static Texture2D brickBlockSpritesheet;
        private static Texture2D questionBlockSpriteSheet;
        private static Texture2D groundBlockSpriteSheet;
        private static Texture2D platformingBlockSpriteSheet;
        private static Texture2D brickBlockCoinDispenserSpriteSheet;
        private static Texture2D BlueBrickBlockSpriteSheet;
        private static Texture2D BlueGroundBlockSpriteSheet;

        public static void Load(ContentManager content){
            hiddenBlockSpritesheet = content.Load<Texture2D>("HiddenBlockSpriteSheet");
            brickBlockSpritesheet = content.Load<Texture2D>("BrickBlockSpriteSheet");
            questionBlockSpriteSheet = content.Load<Texture2D>("QuestionBlockSpriteSheet");
            groundBlockSpriteSheet = content.Load<Texture2D>("GroundBlockSpriteSheet");
            platformingBlockSpriteSheet = content.Load<Texture2D>("PlatformingBlockSpriteSheet");
            brickBlockCoinDispenserSpriteSheet = content.Load<Texture2D>("BrickBlockCoinDispenser");
            BlueBrickBlockSpriteSheet = content.Load<Texture2D>("BlueBrickBlockSpriteSheet");
            BlueGroundBlockSpriteSheet = content.Load<Texture2D>("BlueGroundBlockSpriteSheet");
        }

        public static Texture2D CreateHiddenBlockSprite()
        {
            return hiddenBlockSpritesheet;
        }
        public static Texture2D CreateBrickBlockSprite()
        {
            return brickBlockSpritesheet;
        }
        public static Texture2D CreateQuestionBlockSprite()
        {
            return questionBlockSpriteSheet;
        }
        public static Texture2D CreateGroundBlockSprite()
        {
            return groundBlockSpriteSheet;
        }
        public static Texture2D CreatePlatformingBlockSprite()
        {
            return platformingBlockSpriteSheet;
        }
        public static Texture2D CreateBrickBlockCoinDispenserSprite()
        {
            return brickBlockCoinDispenserSpriteSheet;
        }
        public static Texture2D CreateBlueGroundBlockSprite()
        {
            return BlueGroundBlockSpriteSheet;
        }
        public static Texture2D CreateBlueBrickBlockSprite()
        {
            return BlueBrickBlockSpriteSheet;
        }
    }
}
