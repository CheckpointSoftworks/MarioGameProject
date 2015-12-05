﻿using System;
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
        private static Texture2D iceballSpriteSheet;
        private static Texture2D rightfacingSpritesheet;
        private static Texture2D rightfacingedgeSpritesheet;
        private static Texture2D poleSpriteSheet;
        private static Texture2D flagSpriteSheet;
        private static Texture2D enemyGoombaSpawnerSheet;
        private static Texture2D enemyKoopaSpawnerSheet;
        public static void Load(ContentManager content)
        {
            pipeSpriteSheet = content.Load<Texture2D>(UtilityClass.pipeSpriteSheet);
            brickPiecesSpriteSheet = content.Load<Texture2D>(UtilityClass.brickPiecesSpriteSheet);
            fireballSpriteSheet = content.Load<Texture2D>(UtilityClass.fireballSpriteSheet);
            iceballSpriteSheet = content.Load<Texture2D>(UtilityClass.iceballSpriteSheet);
            rightfacingSpritesheet = content.Load<Texture2D>(UtilityClass.rightFacingPipeSpritesheet);
            rightfacingedgeSpritesheet = content.Load<Texture2D>(UtilityClass.rightFacingEdgePipeSpritesheet);
            poleSpriteSheet = content.Load<Texture2D>(UtilityClass.poleSpriteSheet);
            flagSpriteSheet = content.Load<Texture2D>(UtilityClass.flagSpriteSheet);
            enemyGoombaSpawnerSheet = content.Load<Texture2D>("GoombaEnemySpawnerSprite");
            enemyKoopaSpawnerSheet = content.Load<Texture2D>("KoopaEnemySpawnerSprite");
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
        public static Texture2D CreateIceballSprite()
        {
            return iceballSpriteSheet;
        }

        public static Texture2D CreateRightFacingPipeEdgeSprite()
        {
            return rightfacingedgeSpritesheet;
        }

        public static Texture2D CreatePoleSprite()
        {
            return poleSpriteSheet;
        }

        public static Texture2D CreateFlagSprite()
        {
            return flagSpriteSheet;
        }
        public static Texture2D createGoombaEnemySpawnerSprite()
        {
            return enemyGoombaSpawnerSheet;
        }

        public static Texture2D createKoopaSpawnerSprite()
        {
            return enemyKoopaSpawnerSheet;
        }
    }
}
