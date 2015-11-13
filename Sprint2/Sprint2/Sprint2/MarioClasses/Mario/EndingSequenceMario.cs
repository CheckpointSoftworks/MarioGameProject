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
        private bool atFlagpoleBottom;
        private AnimatedSprite bigFlagpole;
        private AnimatedSprite smallFlagpole;
        private AnimatedSprite fireFlagpole;
        private AnimatedSprite bigWalking;
        private AnimatedSprite smallWalking;
        private AnimatedSprite fireWalking;
        private float slideSpeed;
        public EndingSequenceMario(Vector2 location, bool smallMario, bool fireMario)
        {
            this.location = location;
            this.smallMario = smallMario;
            this.fireMario = fireMario;
            atFlagpoleBottom = false;
            slideSpeed = UtilityClass.slideSpeed;
            bigFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigFlagpoleSprite(), UtilityClass.one, UtilityClass.two, location, UtilityClass.eight);
            smallFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallFlagpoleSprite(), UtilityClass.one, UtilityClass.two, location, UtilityClass.eight);
            fireFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireFlagpoleSprite(), UtilityClass.one, UtilityClass.two, location, UtilityClass.eight);
            bigWalking = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigRunningSprite(), UtilityClass.one, UtilityClass.three, location, UtilityClass.four);
            smallWalking = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallRunningSprite(), UtilityClass.one, UtilityClass.three, location, UtilityClass.four);
            fireWalking = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireRunningSprite(), UtilityClass.one, UtilityClass.three, location, UtilityClass.four);
        }

        private void SlideAnimation()
        {
            if (smallMario)
            {
                if (location.Y < UtilityClass.smallMarioBottomFlagLocY)
                {
                    location.Y += slideSpeed;
                }
                else
                {
                    atFlagpoleBottom = true;
                    location.X = UtilityClass.flipMarioBottomFlagLocX;
                }
            }
            else
            {
                if (location.Y < UtilityClass.bigMarioBottomFlagLocY)
                {
                    location.Y += slideSpeed;
                }
                else
                {
                    atFlagpoleBottom = true;
                    location.X = UtilityClass.flipMarioBottomFlagLocX;
                }
            }
        }
        private void WalkToCastle()
        {

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
            if (!atFlagpoleBottom)
            {
                SlideAnimation();
                if (fireMario)
                { fireFlagpole.Draw(spriteBatch, location, cameraLoc, true); }
                else if (smallMario)
                { smallFlagpole.Draw(spriteBatch, location, cameraLoc, true); }
                else
                { bigFlagpole.Draw(spriteBatch, location, cameraLoc, true); }
            }
            else
            {
                if (fireMario)
                { fireFlagpole.Draw(spriteBatch, location, cameraLoc, false); }
                else if (smallMario)
                { smallFlagpole.Draw(spriteBatch, location, cameraLoc, false); }
                else
                { bigFlagpole.Draw(spriteBatch, location, cameraLoc, false); }
            }
        }
    }
}