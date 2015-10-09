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

        public static void Load(ContentManager content, GraphicsDevice device){
            hiddenBlockSpritesheet = content.Load<Texture2D>("HiddenBlockSpriteSheet");
            brickBlockSpritesheet = content.Load<Texture2D>("BrickBlockSpriteSheet");
            questionBlockSpriteSheet = content.Load<Texture2D>("QuestionBlockSpriteSheet");
            groundBlockSpriteSheet = content.Load<Texture2D>("GroundBlockSpriteSheet");
            platformingBlockSpriteSheet = content.Load<Texture2D>("PlatformingBlockSpriteSheet");
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
    }
}
