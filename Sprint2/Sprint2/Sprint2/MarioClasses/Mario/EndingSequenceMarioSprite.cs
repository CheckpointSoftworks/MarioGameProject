﻿using System;
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
        private AnimatedSprite bigWalking;
        private AnimatedSprite smallWalking;
        private AnimatedSprite fireWalking;
        private Vector2 location;
        private bool smallMario;
        private bool fireMario;
        public EndingSequenceMarioSprite(Vector2 location, bool smallMario, bool fireMario)
        {
            this.location = location;
            this.smallMario = smallMario;
            this.fireMario = fireMario;
            bigFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigFlagpoleSprite(), 1, 2, location, 8);
            smallFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallFlagpoleSprite(), 1, 2, location, 8);
            fireFlagpole = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireFlagpoleSprite(), 1, 2, location, 8);
            bigWalking = new AnimatedSprite(MarioSpriteFactory.CreateMarioBigRunningSprite(), 1, 3, location, 4);
            smallWalking = new AnimatedSprite(MarioSpriteFactory.CreateMarioSmallRunningSprite(), 1, 3, location, 4);
            fireWalking = new AnimatedSprite(MarioSpriteFactory.CreateMarioFireRunningSprite(), 1, 3, location, 4);
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

        public void MarioFlagpoleDrawFacingRight(Vector2 location, SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            if (fireMario)
            { fireFlagpole.Draw(spriteBatch, location, cameraLoc, true); }
            else if (smallMario)
            { smallFlagpole.Draw(spriteBatch, location, cameraLoc, true); }
            else
            { bigFlagpole.Draw(spriteBatch, location, cameraLoc, true); }
        }

        public void MarioFlagpoleDrawFacingLeft(Vector2 location, SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            if (fireMario)
            { fireFlagpole.Draw(spriteBatch, location, cameraLoc, false); }
            else if (smallMario)
            { smallFlagpole.Draw(spriteBatch, location, cameraLoc, false); }
            else
            { bigFlagpole.Draw(spriteBatch, location, cameraLoc, false); }
        }

        public void MarioWalkingDraw(Vector2 location, SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            if (fireMario)
            { fireWalking.Draw(spriteBatch, location, cameraLoc, true); }
            else if (smallMario)
            { smallWalking.Draw(spriteBatch, location, cameraLoc, true); }
            else
            { bigWalking.Draw(spriteBatch, location, cameraLoc, true); }
        }
    }
}