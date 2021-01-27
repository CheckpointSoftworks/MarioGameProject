using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class GoombaEnemySpawnerSprite:ISprite
    {
        private Texture2D goombaEnemySpawnerSpriteSheet;
        private Vector2 location;
        private AnimatedSprite spawnerAnimatedSprite;
        private Rectangle collisionRectangle;

        public GoombaEnemySpawnerSprite(Vector2 location)
        {
            goombaEnemySpawnerSpriteSheet = MiscGameObjectTextureStorage.createGoombaEnemySpawnerSprite();
            this.location = location;
            spawnerAnimatedSprite = new AnimatedSprite(goombaEnemySpawnerSpriteSheet, UtilityClass.one, UtilityClass.one, location, UtilityClass.one);
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
