using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public interface IEnemyObject
    {
        bool DirectionLeft
        { get; set; }
        public void MoveLeft();
        public void MoveRight();
        public void FallLeft();
        public void FallRight();
        public void StopMoving();
        void Update();

        void Draw(SpriteBatch spriteBatch);
                
        Rectangle returnCollisionRectangle();

        void TakeDamage();
    
    }
}
