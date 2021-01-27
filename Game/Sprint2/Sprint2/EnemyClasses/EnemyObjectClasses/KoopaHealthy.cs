using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public class KoopaHealthy : IEnemyState
    {
        private Koopa koopa;
        AnimatedSprite sprite;
        public KoopaHealthy(Koopa Koopa)
        {
            this.koopa = Koopa;
            sprite = new AnimatedSprite(EnemySpriteFactory.CreateKoopaSprite(), UtilityClass.one, UtilityClass.two, koopa.returnLocation(), UtilityClass.generalTotalFramesAndSpecializedRows);
        }

        public void Update()
        {
            sprite.Update();
        }

        public void TakeDamage()
        {
            koopa.State = new KoopaDamaged(koopa);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            sprite.Draw(spriteBatch, koopa.returnLocation(), cameraLoc, koopa.DirectionLeft);
        }
        public void SetDrawColor(Color color)
        {
            sprite.setColorForDrawing(color);
        }
        public Rectangle returnStateCollisionRectangle()
        {
            return sprite.returnCollisionRectangle();
        }
    }
}
