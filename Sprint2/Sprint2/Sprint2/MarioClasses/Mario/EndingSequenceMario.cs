using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class EndingSequenceMario
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
        public EndingSequenceMario(Vector2 location, bool smallMario, bool fireMario)
        {
            this.location = location;
            this.smallMario = smallMario;
            this.fireMario = fireMario;
            atFlagpoleBottom = false;
            offBlock = false;
            flagpoleAnimation = true;
            fallOffBlockAnimation = false;
            walkingToCastle = false;
            slideSpeed = UtilityClass.slideSpeed;
            walkSpeed = UtilityClass.endMarioWalkSpeed;
            decayRate = UtilityClass.endMarioDecayRate;
            waitToLeaveFlagpole = UtilityClass.waitToLeaveFlagpole;
            bigFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigFlagpoleSprite(), UtilityClass.one, UtilityClass.two, location, UtilityClass.eight);
            smallFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallFlagpoleSprite(), UtilityClass.one, UtilityClass.two, location, UtilityClass.eight);
            fireFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireFlagpoleSprite(), UtilityClass.one, UtilityClass.two, location, UtilityClass.eight);
            bigWalking = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigRunningSprite(), UtilityClass.one, UtilityClass.three, location, UtilityClass.four);
            smallWalking = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallRunningSprite(), UtilityClass.one, UtilityClass.three, location, UtilityClass.four);
            fireWalking = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireRunningSprite(), UtilityClass.one, UtilityClass.three, location, UtilityClass.four);
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
                    location.X = UtilityClass.flipMarioBottomFlagLocX;
                }
            }
            else
            {
                if (location.Y < UtilityClass.bigMarioBottomFlagLocY)
                { location.Y += slideSpeed; }
                else
                {
                    atFlagpoleBottom = true;
                    location.X = UtilityClass.flipMarioBottomFlagLocX;
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
                    MarioFlagpoleDrawFacingLeft(spriteBatch, cameraLoc);
                    flagpoleAnimation = false;
                    fallOffBlockAnimation = true;
                }
            }
            if (fallOffBlockAnimation)
            {
                MarioFlagpoleDrawFacingLeft(spriteBatch, cameraLoc);
                waitToLeaveFlagpole--;
                if (waitToLeaveFlagpole <= UtilityClass.zero)
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
            }
        }
    }
}