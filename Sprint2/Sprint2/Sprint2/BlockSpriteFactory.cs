using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint2
{
    public class BlockSpriteFactory
    {
        private static Texture2D hiddenBlockSpritesheet;
        private static Texture2D brickBlockSpritesheet;
        private static Texture2D questionBlockSpriteSheet;
        private static Texture2D groundBlockSpriteSheet;
        private static Texture2D platformingBlockSpriteSheet;

        public static void Load(ContentManager content, GraphicsDevice device){
            hiddenBlockSpritesheet=content.Load<Texture2D>("MarioTileSet");
            brickBlockSpritesheet=content.Load<Texture2D>("MarioTileSet");
            questionBlockSpriteSheet=content.Load<Texture2D>("MarioTileSet");
            groundBlockSpriteSheet=content.Load<Texture2D>("MarioTileSet");
            platformingBlockSpriteSheet = content.Load<Texture2D>("MarioTileSet");
        }

        public static IGameObject CreateHiddenBlockSprite()
        {
            return new HiddenBlock();
        }
        public static IGameObject CreateBrickBlockSprite()
        {
            return new BrickBlock();
        }
        public static IGameObject CreateQuestionBlockSprite()
        {
            return new QuestionBlock();
        }
        public static IGameObject CreateGroundBlockSprite()
        {
            return new GroundBlock();
        }
        public static IGameObject CreatePlatformingBlockSprite()
        {
            return new HiddenBlock();
        }
    }
}
