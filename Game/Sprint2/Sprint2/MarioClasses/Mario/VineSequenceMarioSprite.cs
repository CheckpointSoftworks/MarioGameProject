using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class VineSequenceMarioSprite
    {
        private AnimatedSprite bigFlagpole;
        private AnimatedSprite smallFlagpole;
        private AnimatedSprite fireFlagpole;
        private AnimatedSprite iceFlagpole;
        private bool smallMario;
        private bool fireMario;
        private bool iceMario;

        public VineSequenceMarioSprite(Vector2 location, bool smallMario, bool fireMario, bool iceMario)
        {
            this.smallMario = smallMario;
            this.fireMario = fireMario;
            this.iceMario = iceMario;
            bigFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigFlagpoleSprite(), UtilityClass.one, UtilityClass.two, location, UtilityClass.enemyTotalFramesAndMarioFlagpoleTotalFrames);
            smallFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallFlagpoleSprite(), UtilityClass.one, UtilityClass.two, location, UtilityClass.enemyTotalFramesAndMarioFlagpoleTotalFrames);
            fireFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireFlagpoleSprite(), UtilityClass.one, UtilityClass.two, location, UtilityClass.enemyTotalFramesAndMarioFlagpoleTotalFrames);
            iceFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioIceFlagpoleSprite(), UtilityClass.one, UtilityClass.two, location, UtilityClass.enemyTotalFramesAndMarioFlagpoleTotalFrames);
        }
        public void Update()
        {
            bigFlagpole.Update();
            smallFlagpole.Update();
            fireFlagpole.Update();
            iceFlagpole.Update();
        }
        public void MarioVineDrawFacingRight(Vector2 sentLocation, SpriteBatch spriteBatch, Vector2 cameraLoc)
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
        public void MarioVineDrawFacingLeft(Vector2 sentLocation, SpriteBatch spriteBatch, Vector2 cameraLoc)
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
    }

}
