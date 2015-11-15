using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class EndingSequenceMario : IEndingSequenceMario
    {
        private Vector2 location;
        private bool smallMario;
        private bool fireMario;
        private bool flagpoleAnimation;
        private bool atFlagpoleBottom;
        private bool fallOffBlockAnimation;
        private bool offBlock;
        private bool walkingToCastle;
        private float slideSpeed;
        private float walkSpeed;
        private float decayRate;
        private int waitToLeaveFlagpole;
        private AnimatedSprite bigFlagpole;
        private AnimatedSprite smallFlagpole;
        private AnimatedSprite fireFlagpole;
        private AnimatedSprite bigWalking;
        private AnimatedSprite smallWalking;
        private AnimatedSprite fireWalking;
        private bool flagAtBottom;
        public bool FlagAtBottom
        {
            set { flagAtBottom = value; }
        }
        bool endSequenceFinished;
        public bool EndSequenceFinished
        {
            get { return endSequenceFinished; }
        }
        public EndingSequenceMario(Vector2 location, bool smallMario, bool fireMario)
        {
            this.location = location;
            this.smallMario = smallMario;
            this.fireMario = fireMario;
            endSequenceFinished = false;
            atFlagpoleBottom = false;
            flagAtBottom = false;
            offBlock = false;
            flagpoleAnimation = true;
            fallOffBlockAnimation = false;
            walkingToCastle = false;
            slideSpeed = UtilityClass.slideSpeed;
            walkSpeed = UtilityClass.endMarioWalkSpeed;
            decayRate = UtilityClass.endMarioDecayRate;
            waitToLeaveFlagpole = UtilityClass.waitToLeaveFlagpole;
            bigFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigFlagpoleSprite(), 1, 2, location, 8);
            smallFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallFlagpoleSprite(), 1, 2, location, 8);
            fireFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireFlagpoleSprite(), 1, 2, location, 8);
            bigWalking = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigRunningSprite(), 1, 3, location, 4);
            smallWalking = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallRunningSprite(), 1, 3, location, 4);
            fireWalking = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireRunningSprite(), 1, 3, location, 4);
        }

        private void SlideDownPole()
        {
            if (smallMario)
            {
                if (location.Y < UtilityClass.smallMarioBottomFlagLocY)
                { location.Y += slideSpeed; }
                else
                {
                    atFlagpoleBottom = true;
                }
            }
            else
            {
                if (location.Y < UtilityClass.bigMarioBottomFlagLocY)
                { location.Y += slideSpeed; }
                else
                {
                    atFlagpoleBottom = true;
                }
            }
        }
        private void FallOffBlock()
        {
            if (smallMario)
            {
                if (location.Y < UtilityClass.smallMarioGroundLocY)
                { 
                    location.X += walkSpeed;
                    location.Y += (slideSpeed * decayRate);
                }
                else { offBlock = true; }
            }
            else
            {
                if (location.Y < UtilityClass.bigMarioGroundLocY)
                {
                    location.X += walkSpeed;
                    location.Y += (slideSpeed * decayRate); 
                }
                else { offBlock = true; }
            }
        }

        private void WalkToCastle()
        {
            location.X += walkSpeed;
        }

        private void MarioFlagpoleDrawFacingRight(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            if (fireMario)
            { fireFlagpole.Draw(spriteBatch, location, cameraLoc, true); }
            else if (smallMario)
            { smallFlagpole.Draw(spriteBatch, location, cameraLoc, true); }
            else
            { bigFlagpole.Draw(spriteBatch, location, cameraLoc, true); }
        }

        private void MarioFlagpoleDrawFacingLeft(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            if (fireMario)
            { fireFlagpole.Draw(spriteBatch, location, cameraLoc, false); }
            else if (smallMario)
            { smallFlagpole.Draw(spriteBatch, location, cameraLoc, false); }
            else
            { bigFlagpole.Draw(spriteBatch, location, cameraLoc, false); }
        }

        private void MarioWalkingDraw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            if (fireMario)
            { fireWalking.Draw(spriteBatch, location, cameraLoc, true); }
            else if (smallMario)
            { smallWalking.Draw(spriteBatch, location, cameraLoc, true); }
            else
            { bigWalking.Draw(spriteBatch, location, cameraLoc, true); }
        }

        public void Update()
        {
            bigFlagpole.Update();
            smallFlagpole.Update();
            fireFlagpole.Update();
            bigWalking.Update();
            smallWalking.Update();
            fireWalking.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            if (flagpoleAnimation)
            {
                if (!atFlagpoleBottom)
                {
                    SlideDownPole();
                    MarioFlagpoleDrawFacingRight(spriteBatch, cameraLoc);
                }
                else
                {
                    if (!flagAtBottom)
                    { MarioFlagpoleDrawFacingRight(spriteBatch, cameraLoc); }
                    else 
                    {
                        location.X = UtilityClass.flipMarioBottomFlagLocX;
                        MarioFlagpoleDrawFacingLeft(spriteBatch, cameraLoc);
                        flagpoleAnimation = false;
                        fallOffBlockAnimation = true;
                    }
                }
            }
            if (fallOffBlockAnimation)
            {
                MarioFlagpoleDrawFacingLeft(spriteBatch, cameraLoc);
                waitToLeaveFlagpole--;
                if (waitToLeaveFlagpole <= 0)
                {
                    if (!offBlock)
                    {
                        FallOffBlock();
                        MarioWalkingDraw(spriteBatch, cameraLoc);
                    }
                    else
                    {
                        MarioWalkingDraw(spriteBatch, cameraLoc);
                        fallOffBlockAnimation = false;
                        walkingToCastle = true;
                    }
                }
            }
            if (walkingToCastle)
            {
                if (location.X < UtilityClass.castleDoorWayLocX)
                {
                    WalkToCastle();
                    MarioWalkingDraw(spriteBatch, cameraLoc);
                }
                else
                { endSequenceFinished = true; }
            }
        }
    }
}