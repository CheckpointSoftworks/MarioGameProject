using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class EndingSequenceMarioSprite : IEndingSequenceMarioSprite
    {
        private AnimatedSprite bigFlagpole;
        private AnimatedSprite smallFlagpole;
        private AnimatedSprite fireFlagpole;
        private AnimatedSprite iceFlagpole;
        private AnimatedSprite bigWalking;
        private AnimatedSprite smallWalking;
        private AnimatedSprite fireWalking;
        private AnimatedSprite iceWalking;
        private bool smallMario;
        private bool fireMario;
        private bool iceMario;
        public EndingSequenceMarioSprite(Vector2 location, bool smallMario, bool fireMario, bool iceMario)
        {
            this.smallMario = smallMario;
            this.fireMario = fireMario;
            this.iceMario = iceMario;
            bigFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigFlagpoleSprite(), UtilityClass.one, UtilityClass.two, location, UtilityClass.enemyTotalFramesAndMarioFlagpoleTotalFrames);
            smallFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallFlagpoleSprite(), UtilityClass.one, UtilityClass.two, location, UtilityClass.enemyTotalFramesAndMarioFlagpoleTotalFrames);
            fireFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireFlagpoleSprite(), UtilityClass.one, UtilityClass.two, location, UtilityClass.enemyTotalFramesAndMarioFlagpoleTotalFrames);
            iceFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioIceFlagpoleSprite(), UtilityClass.one, UtilityClass.two, location, UtilityClass.enemyTotalFramesAndMarioFlagpoleTotalFrames);
            bigWalking = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigRunningSprite(), UtilityClass.one, UtilityClass.specializedSpriteTotalFramesAndMarioRunningCols, location, UtilityClass.generalTotalFramesAndSpecializedRows);
            smallWalking = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallRunningSprite(), UtilityClass.one, UtilityClass.specializedSpriteTotalFramesAndMarioRunningCols, location, UtilityClass.generalTotalFramesAndSpecializedRows);
            fireWalking = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireRunningSprite(), UtilityClass.one, UtilityClass.specializedSpriteTotalFramesAndMarioRunningCols, location, UtilityClass.generalTotalFramesAndSpecializedRows);
            iceWalking = new AnimatedSprite(MarioSpriteFactory.CreateMarioIceRunningSprite(), UtilityClass.one, UtilityClass.specializedSpriteTotalFramesAndMarioRunningCols, location, UtilityClass.generalTotalFramesAndSpecializedRows);
        }
        public void Update()
        {
            bigFlagpole.Update();
            smallFlagpole.Update();
            fireFlagpole.Update();
            iceFlagpole.Update();
            bigWalking.Update();
            smallWalking.Update();
            fireWalking.Update();
            iceWalking.Update();
        }

        public void MarioFlagpoleDrawFacingRight(Vector2 sentLocation, SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            if (fireMario)
            { fireFlagpole.Draw(spriteBatch, sentLocation, cameraLoc, true); }
            else if (iceMario)
            { iceFlagpole.Draw(spriteBatch, sentLocation, cameraLoc, true); }
            else if (smallMario)
            { smallFlagpole.Draw(spriteBatch, sentLocation, cameraLoc, true); }
            else
            { bigFlagpole.Draw(spriteBatch, sentLocation, cameraLoc, true); }
        }

        public void MarioFlagpoleDrawFacingLeft(Vector2 sentLocation, SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            if (fireMario)
            { fireFlagpole.Draw(spriteBatch, sentLocation, cameraLoc, false); }
            else if (iceMario)
            { iceFlagpole.Draw(spriteBatch, sentLocation, cameraLoc, false); }
            else if (smallMario)
            { smallFlagpole.Draw(spriteBatch, sentLocation, cameraLoc, false); }
            else
            { bigFlagpole.Draw(spriteBatch, sentLocation, cameraLoc, false); }
        }

        public void MarioWalkingDraw(Vector2 sentLocation, SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            if (fireMario)
            { fireWalking.Draw(spriteBatch, sentLocation, cameraLoc, true); }
            else if (iceMario)
            { iceWalking.Draw(spriteBatch, sentLocation, cameraLoc, true); }
            else if (smallMario)
            { smallWalking.Draw(spriteBatch, sentLocation, cameraLoc, true); }
            else
            { bigWalking.Draw(spriteBatch, sentLocation, cameraLoc, true); }
        }
    }
}
