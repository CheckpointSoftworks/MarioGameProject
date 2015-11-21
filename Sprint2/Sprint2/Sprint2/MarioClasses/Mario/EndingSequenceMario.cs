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

        private EndingSequenceMarioSprite endMarioSprite;
        private Vector2 location;
        private bool smallMario;
        private bool flagpoleAnimation;
        private bool atFlagpoleBottom;
        private bool fallOffBlockAnimation;
        private bool offBlock;
        private bool walkingToCastle;
        private float slideSpeed;
        private float walkSpeed;
        private float decayRate;
        private int waitToLeaveFlagpole;
        private bool flagAtBottom;
        private PlayerActionStatManager endActions;
        private PlayerStatManager endStats;
        public bool FlagAtBottom
        {
            get { return flagAtBottom; }
            set { flagAtBottom = value; }
        }
        bool endSequenceFinished;
        public bool EndSequenceFinished
        {
            get { return endSequenceFinished; }
            set { endSequenceFinished = value; }
        }
        public EndingSequenceMario(Mario mario, bool smallMario, bool fireMario)
        {
            this.location = mario.Location;
            endActions = mario.actions;
            endStats = mario.stats;
            this.smallMario = smallMario;
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
            endMarioSprite = new EndingSequenceMarioSprite(location, smallMario, fireMario);
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

        public void Update()
        {
            endMarioSprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc, SpriteFont font)
        {
            endStats.DrawTotals(spriteBatch,font, UtilityClass.GUICollectableStatsPosition);
            endActions.DrawTotals(spriteBatch, font, UtilityClass.GUIActionStatsPosition);
            if (flagpoleAnimation)
            {
                if (!atFlagpoleBottom)
                {
                    SlideDownPole();
                    endMarioSprite.MarioFlagpoleDrawFacingRight(location, spriteBatch, cameraLoc);
                }
                else
                {
                    if (!flagAtBottom)
                    { endMarioSprite.MarioFlagpoleDrawFacingRight(location, spriteBatch, cameraLoc); }
                    else 
                    {
                        location.X = UtilityClass.flipMarioBottomFlagLocX;
                        endMarioSprite.MarioFlagpoleDrawFacingLeft(location, spriteBatch, cameraLoc);
                        flagpoleAnimation = false;
                        fallOffBlockAnimation = true;
                    }
                }
            }
            if (fallOffBlockAnimation)
            {
                endMarioSprite.MarioFlagpoleDrawFacingLeft(location, spriteBatch, cameraLoc);
                waitToLeaveFlagpole--;
                if (waitToLeaveFlagpole <= UtilityClass.zero)
                {
                    if (!offBlock)
                    {
                        FallOffBlock();
                        endMarioSprite.MarioWalkingDraw(location, spriteBatch, cameraLoc);
                    }
                    else
                    {
                        endMarioSprite.MarioWalkingDraw(location, spriteBatch, cameraLoc);
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
                    endMarioSprite.MarioWalkingDraw(location, spriteBatch, cameraLoc);
                }
                else
                { endSequenceFinished = true; }
            }
        }
    }
}