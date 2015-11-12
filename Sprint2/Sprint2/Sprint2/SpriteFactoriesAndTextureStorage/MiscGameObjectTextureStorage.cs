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
        private static Texture2D rightfacingSpritesheet;
        private static Texture2D rightfacingedgeSpritesheet;
        public static void Load(ContentManager content)
        {
            pipeSpriteSheet = content.Load<Texture2D>(UtilityClass.pipeSpriteSheet);
            brickPiecesSpriteSheet = content.Load<Texture2D>(UtilityClass.brickPiecesSpriteSheet);
            fireballSpriteSheet = content.Load<Texture2D>(UtilityClass.fireballSpriteSheet);
            rightfacingSpritesheet = content.Load<Texture2D>("RightFacingPipeSprite");
            rightfacingedgeSpritesheet = content.Load<Texture2D>("RightFacingPipeTallEdge");
        }

        public static Texture2D CreatePipeSprite()
        {
            return pipeSpriteSheet;
        }
        public static Texture2D CreateRightFacingPipeSprite()
        {
            return rightfacingSpritesheet;
        }
        public static Texture2D CreateBrickPiecesSprite()
        {
            return brickPiecesSpriteSheet;
        }

        public static Texture2D CreateFireballSprite()
        {
            return fireballSpriteSheet;
        }

        public static Texture2D CreateRightFacingPipeEdgeSprite()
        {
            return rightfacingedgeSpritesheet;
        }
    }
}
