using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint2
{
    public static class MiscGameObjectTextureStorage
    {
        private static Texture2D pipeSpriteSheet;
        private static Texture2D brickPiecesSpriteSheet;
        private static Texture2D fireballSpriteSheet;

        public static void Load(ContentManager content)
        {
            pipeSpriteSheet = content.Load<Texture2D>("PipeSprite");
            brickPiecesSpriteSheet = content.Load<Texture2D>("BrickPieces");
            fireballSpriteSheet = content.Load<Texture2D>("FireballSprite");
        }

        public static Texture2D CreatePipeSprite()
        {
            return pipeSpriteSheet;
        }
        public static Texture2D CreateBrickPiecesSprite()
        {
            return brickPiecesSpriteSheet;
        }

        public static Texture2D CreateFireballSprite()
        {
            return fireballSpriteSheet;
        }
    }
}
