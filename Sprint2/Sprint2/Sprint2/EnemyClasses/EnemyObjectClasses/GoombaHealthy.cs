using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class GoombaHealthy: IEnemyState
    {
        private Goomba goomba;
        AnimatedSprite sprite;
        public GoombaHealthy(Goomba goomba)
        {
            this.goomba = goomba;
            sprite = new AnimatedSprite(EnemySpriteFactory.CreateGoombaSprite(), UtilityClass.one, UtilityClass.two, goomba.returnLocation(), UtilityClass.generalTotalFramesAndSpecializedRows);
        }

        public void Update()
        {
            sprite.Update();
        }

        public void TakeDamage()
        {
            goomba.State = new GoombaDamaged(goomba);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            sprite.Draw(spriteBatch, goomba.returnLocation(), cameraLoc, goomba.DirectionLeft);
        }
        public Rectangle returnStateCollisionRectangle()
        {           
            return sprite.returnCollisionRectangle();
        }
    }
}
