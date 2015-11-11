using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class GoombaDamaged : IEnemyState
    {
        private Goomba goomba;
        AnimatedSprite sprite;
        public GoombaDamaged(Goomba goomba)
        {
            this.goomba = goomba;
            sprite = new AnimatedSprite(EnemySpriteFactory.CreateGoombaDamangedSprite(), UtilityClass.one, UtilityClass.one, goomba.returnLocation(), UtilityClass.four);
        }

        public void Update()
        {
            sprite.Update();
        }

        public void TakeDamage()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            sprite.Draw(spriteBatch, goomba.returnLocation(), cameraLoc, true);
        }
        public Rectangle returnStateCollisionRectangle()
        {
            return new Rectangle(UtilityClass.zero, UtilityClass.zero, UtilityClass.zero, UtilityClass.zero);
        }
    }
}