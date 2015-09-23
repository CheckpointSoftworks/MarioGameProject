using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint2
{
    class MarioSpriteFactory
    {
        /*
        private static Texture2D marioRightSmallStill;
        private static Texture2D marioRightSmallRunning;
        private static Texture2D marioRightSmallJumping;
        private static Texture2D marioRightBigStill;
        private static Texture2D marioRightBigRunning;
        private static Texture2D marioRightBigJumping;
        private static Texture2D marioRightShootFireball;

        
        private static Texture2D marioLeftSmallStill;
        private static Texture2D marioLeftSmallRunning;
        private static Texture2D marioLeftSmallJumping;
        private static Texture2D marioLeftBigStill;
        private static Texture2D marioLeftBigRunning;
        private static Texture2D marioLeftBigJumping;
        private static Texture2D marioLeftShootFireball;
        */

        private static Texture2D marioSmallStill;
        private static Texture2D marioSmallRunning;
        private static Texture2D marioSmallJumping;
        private static Texture2D marioSmallFlagpole;
        private static Texture2D marioBigStill;
        private static Texture2D marioBigRunning;
        private static Texture2D marioBigJumping;
        private static Texture2D marioShootFireball;
        private static Texture2D marioBigFlagpole;

        private static Texture2D marioDuck;
        private static Texture2D marioDying;


        public static void Load(ContentManager content, GraphicsDevice device)
        {
            /*
             marioRightSmallStill = content.Load<Texture2D>("");
             marioRightSmallRunning = content.Load<Texture2D>("");
             marioRightSmallJumping = content.Load<Texture2D>("");
             marioRightBigStill = content.Load<Texture2D>("");
             marioRightBigRunning = content.Load<Texture2D>("");
             marioRightBigJumping = content.Load<Texture2D>("");
             marioRightShootFireball = content.Load<Texture2D>("");

            
             marioLeftSmallStill = content.Load<Texture2D>("");
             marioLeftSmallRunning = content.Load<Texture2D>("");
             marioLeftSmallJumping = content.Load<Texture2D>("");
             marioLeftBigStill = content.Load<Texture2D>("");
             marioLeftBigRunning = content.Load<Texture2D>("");
             marioLeftBigJumping = content.Load<Texture2D>("");
             marioLeftShootFireball = content.Load<Texture2D>("");
             * */

            marioSmallStill = content.Load<Texture2D>("");
            marioSmallRunning = content.Load<Texture2D>("");
            marioSmallJumping = content.Load<Texture2D>("");
            marioSmallFlagpole = content.Load<Texture2D>("");
            marioBigStill = content.Load<Texture2D>("");
            marioBigRunning = content.Load<Texture2D>("");
            marioBigJumping = content.Load<Texture2D>("");
            marioShootFireball = content.Load<Texture2D>("");
            marioBigFlagpole = content.Load<Texture2D>("");

            marioDuck = content.Load<Texture2D>("");
            marioDying = content.Load<Texture2D>("");
        }

        public static Texture2D CreateMarioSmallStillSprite(bool facingRight)
        {

            return marioSmallStill;
        }
        public static Texture2D CreateMarioSmallRunningSprite(bool facingRight)
        {

            return marioSmallRunning;
        }
        public static Texture2D CreateMarioSmallJumpingSprite(bool facingRight)
        {

            return marioSmallJumping;
        }
        public static Texture2D CreateMarioSmallFlagpoleSprite(bool facingRight)
        {

            return marioSmallFlagpole;
        }
        public static Texture2D CreateMarioBigStillSprite(bool facingRight)
        {

            return marioBigStill;
        }
        public static Texture2D CreateMarioBigRunningSprite(bool facingRight)
        {

            return marioBigRunning;
        }
        public static Texture2D CreateMarioBigJumpingSprite(bool facingRight)
        {

            return marioBigJumping;
        }
        public static Texture2D CreateMarioBigFlagpoleSprite(bool facingRight)
        {

            return marioBigFlagpole;
        }
        public static Texture2D CreateMarioDuckSprite(bool facingRight)
        {

            return marioDuck;
        }
        public static Texture2D CreateMarioDyingSprite(bool facingRight)
        {

            return marioDying;
        }
    }


}
