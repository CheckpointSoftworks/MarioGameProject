using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class BrickPieces:IEnviromental
    {
        private ISprite sprite;
        private bool testForCollisionFlag;
        
        public BrickPieces(int locX,int locY,bool moveDirection)
        {
            Vector2 location = new Vector2(locX, locY);
            sprite = new BrickPiecesSprite(location,moveDirection);
            testForCollisionFlag=false;
        }
        public void Update()
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            sprite.Draw(spriteBatch, cameraLoc);
        }

        public Rectangle returnCollisionRectangle()
        {
            return new Rectangle(UtilityClass.zero,UtilityClass.zero,UtilityClass.zero,UtilityClass.zero);
        }
        public bool testForCollision()
        {
            return testForCollisionFlag;
        }
    }
}
