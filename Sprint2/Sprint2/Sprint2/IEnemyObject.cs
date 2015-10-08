using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public interface IEnemyObject:IGameObject
    {
        public enum EnemyType { Goomba, Koopa };
        void Update();

        void Draw(SpriteBatch spriteBatch);

        EnemyType retrunEnemyType();
        
        Rectangle returnCollisionRectange();
    
    }
}
