using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class EnemySpawner:IEnviromental
    { 
        private ISprite spawnerSprite;
        private int timerForSpawn;
        private bool spawnEnemy;
        private bool goombaSpawner;
        private Vector2 location;

        public EnemySpawner(int locX, int locY,bool goombaOrKoopa)
        {
            location = new Vector2(locX, locY);
            if (goombaOrKoopa)
            {
                spawnerSprite = new GoombaEnemySpawnerSprite(location);
            }
            else
            {
                spawnerSprite = new KoopaEnemySpawnerSprite(location);
            }
            timerForSpawn = UtilityClass.spawnTimer;
            spawnEnemy = false;
            goombaSpawner = goombaOrKoopa;
        }

        public void Update()
        {
            spawnerSprite.Update();
            if (timerForSpawn == UtilityClass.zero)
            {
                spawnEnemy = true;
                timerForSpawn = UtilityClass.spawnTimer;
            }
            else
            {
                spawnEnemy = false;
                timerForSpawn--;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraLoc)
        {
            spawnerSprite.Draw(spriteBatch, cameraLoc);
        }

        public Rectangle returnCollisionRectangle()
        {
            return spawnerSprite.returnCollisionRectangle();
        }

        public bool testForCollision()
        {
            return true;
        }

        public bool timeToSpawnAnEnemy()
        {
            return spawnEnemy;
        }

        public IEnemyObject SpawnAnEnemy()
        {
            IEnemyObject newEnemy;
            if (goombaSpawner)
            {
                newEnemy = new Goomba((int)location.X + UtilityClass.enemySpawnXOffset, (int)location.Y - UtilityClass.enemySpawnYOffset);
            }
            else
            {
                newEnemy = new Koopa((int)location.X + UtilityClass.enemySpawnXOffset, (int)location.Y - UtilityClass.enemySpawnYOffset);
            }
            return newEnemy;
        }

        public Vector2 returnLocation()
        {
            return location;
        }
    }
}
