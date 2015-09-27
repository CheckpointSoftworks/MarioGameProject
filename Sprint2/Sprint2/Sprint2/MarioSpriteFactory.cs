using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Sprint2
{
    public static class MarioSpriteFactory
    {
        private static Texture2D marioSmallStill;
        private static Texture2D marioSmallRunning;
        private static Texture2D marioSmallJumping;
      //private static Texture2D marioSmallFlagpole;
        private static Texture2D marioSmallChangeDirection;

        private static Texture2D marioBigStill;
        private static Texture2D marioBigRunning;
        private static Texture2D marioBigJumping;
        private static Texture2D marioBigFlagpole;

        private static Texture2D marioFireStill;
        private static Texture2D marioFireRunning;
        private static Texture2D marioFireJumping;
        private static Texture2D marioFireDuck;
      //private static Texture2D marioFireShootFireball;
      //private static Texture2D marioFireFlagpole;
        private static Texture2D marioFireChangeDirection;

        private static Texture2D marioDuck;
        private static Texture2D marioDying;
        private static Texture2D marioBigChangeDirection;

        public static void Load(ContentManager content)
        {
            marioSmallStill = content.Load<Texture2D>("MarioSmallStill");
            marioSmallRunning = content.Load<Texture2D>("MarioSmallRunning");
            marioSmallJumping = content.Load<Texture2D>("MarioSmallJump");
          //marioSmallFlagpole = content.Load<Texture2D>("MarioSmallFlagpole");
            marioSmallChangeDirection = content.Load<Texture2D>("MarioSmallChangeDirection");

            marioBigStill = content.Load<Texture2D>("MarioBigStill");
            marioBigRunning = content.Load<Texture2D>("MarioBigRunning");
            marioBigJumping = content.Load<Texture2D>("MarioBigJump");
            marioBigFlagpole = content.Load<Texture2D>("MarioBigFlagpole");
            marioBigChangeDirection = content.Load<Texture2D>("MarioBigChangeDirection");

            marioFireStill = content.Load<Texture2D>("MarioFireStill");
            
            marioFireRunning = content.Load<Texture2D>("MarioFireRunning");
            marioFireJumping = content.Load<Texture2D>("MarioFireJump");
            marioFireDuck = content.Load<Texture2D>("MarioFireDuck");
            marioFireChangeDirection = content.Load<Texture2D>("MarioFireChangeDirection");
          //marioFireShootFireball = content.Load<Texture2D>("MarioFireShootingStill");
          //marioFireFlagpole = content.Load<Texture2D>("MarioFireFlagpole");

            marioDuck = content.Load<Texture2D>("MarioDuck");
            marioDying = content.Load<Texture2D>("MarioDying");

        }

        public static Texture2D CreateMarioSmallStillSprite()
        {
            return marioSmallStill;
        }
        public static Texture2D CreateMarioSmallRunningSprite()
        {

            return marioSmallRunning;
        }
        public static Texture2D CreateMarioSmallJumpingSprite()
        {
            return marioSmallJumping;
        }/*
        public static Texture2D CreateMarioSmallFlagpoleSprite()
        {

            return marioSmallFlagpole;
        }*/
        public static Texture2D CreateMarioSmallChangeDirectionSprite()
        {

            return marioSmallChangeDirection;
        }
        public static Texture2D CreateMarioBigStillSprite()
        {

            return marioBigStill;
        }
        public static Texture2D CreateMarioBigRunningSprite()
        {

            return marioBigRunning;
        }
        public static Texture2D CreateMarioBigJumpingSprite()
        {

            return marioBigJumping;
        }
        public static Texture2D CreateMarioBigChangeDirectionSprite()
        {

            return marioBigChangeDirection;
        }
        public static Texture2D CreateMarioBigFlagpoleSprite()
        {

            return marioBigFlagpole;
        }
        public static Texture2D CreateMarioFireStillSprite()
        {

            return marioFireStill;
        }
        public static Texture2D CreateMarioFireRunningSprite()
        {

            return marioFireRunning;
        }
        public static Texture2D CreateMarioFireChangeDirectionSprite()
        {

            return marioFireChangeDirection;
        }
        public static Texture2D CreateMarioFireJumpingSprite()
        {

            return marioFireJumping;
        }
        public static Texture2D CreateMarioFireDuckSprite()
        {

            return marioFireDuck;
        }
        public static Texture2D CreateMarioDuckSprite()
        {

            return marioDuck;
        }
        
        public static Texture2D CreateMarioDyingSprite()
        {
            return marioDying;
        }
    }


}
