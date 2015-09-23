using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint2
{
    public class MarioSpriteFactory
    {
        private static Texture2D marioSmallStill;
        private static Texture2D marioSmallRunning;
        private static Texture2D marioSmallJumping;
        private static Texture2D marioSmallFlagpole;
        private static Texture2D marioSmallChangeDirection;

        private static Texture2D marioBigStill;
        private static Texture2D marioBigRunning;
        private static Texture2D marioBigJumping;
        private static Texture2D marioShootFireball;
        private static Texture2D marioBigFlagpole;

        private static Texture2D marioDuck;
        private static Texture2D marioDying;
        private static Texture2D marioBigChangeDirection;

        public MarioSpriteFactory()
        {
            //Nothing
        }

        public static void Load(ContentManager content, GraphicsDevice device)
        {
            marioSmallStill = content.Load<Texture2D>("MarioSmallStill");
            marioSmallRunning = content.Load<Texture2D>("MarioSmallRunning");
            marioSmallJumping = content.Load<Texture2D>("MarioSmallJump");
            //marioSmallFlagpole = content.Load<Texture2D>("MarioSmallFlagpole");
            marioSmallChangeDirection = content.Load<Texture2D>("MarioSmallChangeDirection");

            marioBigStill = content.Load<Texture2D>("MarioBigStill");
            marioBigRunning = content.Load<Texture2D>("MarioBigRunning");
            marioBigJumping = content.Load<Texture2D>("MarioBigJump");
            marioShootFireball = content.Load<Texture2D>("MarioShoot");
           // marioBigFlagpole = content.Load<Texture2D>("MarioBigFlagpole");
            marioBigChangeDirection = content.Load<Texture2D>("MarioBigChangeDirection");

            marioDuck = content.Load<Texture2D>("MarioDuck");
            marioDying = content.Load<Texture2D>("MarioDying");
            
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
