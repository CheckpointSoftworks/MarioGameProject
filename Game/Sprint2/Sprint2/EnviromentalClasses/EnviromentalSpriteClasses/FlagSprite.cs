using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class FlagSprite : IFlagSprite
    {
        private AnimatedSprite flagSprite;
        private Texture2D flagSpriteSheet;
        private Vector2 location;
        private float moveSpeed;
        private bool flagAtBottom;
        public bool FlagAtBottom 
        {
            get { return flagAtBottom; }
        }
        public FlagSprite(Vector2 location)
        {
            this.location = location;
            moveSpeed = UtilityClass.flagMoveSpeed;
            flagAtBottom = false;
            flagSpriteSheet = MiscGameObjectTextureStorage.CreateFlagSprite();
            flagSprite = new AnimatedSprite(flagSpriteSheet, 1, 1, location, 1);
        }

        public void Update()
        {
            flagSprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            flagSprite.Draw(spriteBatch, location, cameraLoc, true);
        }
        public void MoveDown()
        {
            if (location.Y <= UtilityClass.flagAtBottomLocationY)
            {
                location.Y += moveSpeed;
                if (location.Y > UtilityClass.flagAtBottomLocationY)
                {
                    flagAtBottom = true;
                }
            }
        }
    }
}
