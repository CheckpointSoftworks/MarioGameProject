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
        private BlockType type;
        private bool testForCollisionFlag;
        private bool noLongerSpecialized;
        
        public BrickPieces(int locX,int locY,bool moveDirection)
        {
            Vector2 location = new Vector2(locX, locY);
            sprite = new BrickPiecesSprite(location,moveDirection);
            this.type = BlockType.Brick;
            testForCollisionFlag=false;
            noLongerSpecialized = false;
        }
        public void Update()
        {
            sprite.Update();
            noLongerSpecialized = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public Rectangle returnCollisionRectangle()
        {
            return new Rectangle(0,0,0,0);
        }
        public bool testForCollision()
        {
            return testForCollisionFlag;
        }
    }
}
