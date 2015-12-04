using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class KoopaEnemySpawnerSprite:ISprite
    {
        private Texture2D koopaEnemySpawnerSpriteSheet;
        private Vector2 location;
        private AnimatedSprite spawnerAnimatedSprite;
        private Rectangle collisionRectangle;

        public KoopaEnemySpawnerSprite(Vector2 location)
        {
            koopaEnemySpawnerSpriteSheet = MiscGameObjectTextureStorage.createKoopaSpawnerSprite();
            this.location = location;
            spawnerAnimatedSprite = new AnimatedSprite(koopaEnemySpawnerSpriteSheet, UtilityClass.one, UtilityClass.one, location, UtilityClass.one);
            collisionRectangle = spawnerAnimatedSprite.returnCollisionRectangle();
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            spawnerAnimatedSprite.Draw(spriteBatch, location, cameraLoc, true);
        }

        public Rectangle returnCollisionRectangle()
        {
            return collisionRectangle;
        }
    }
}
