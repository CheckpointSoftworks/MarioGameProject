using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class Flag : IFlag
    {
        private IFlagSprite flagSprite;
        private Vector2 location;
        public Flag()
        {
            location = new Vector2(UtilityClass.flagLocationX, UtilityClass.flagLocationY);
            flagSprite = new FlagSprite(location);
        }
        public void Update()
        {
            flagSprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            flagSprite.Draw(spriteBatch, cameraLoc);
        }
        public void MoveDown() 
        {
            flagSprite.MoveDown();
        }
        public bool FlagAtBottom()
        {
            return flagSprite.FlagAtBottom;
        }
    }
}
