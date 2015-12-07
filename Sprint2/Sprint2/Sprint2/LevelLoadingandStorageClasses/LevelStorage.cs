using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Sprint2
{
    public class LevelStorage
    {
        public Camera camera { get; set; }
        public IPlayer player { get; set; }
        public ArrayList itemList;
        public ArrayList enemiesList;
        public ArrayList blocksList;
        public ArrayList enviromentalObjectsList;
        public ArrayList projectileList;
        private int enemyCount;
        private int maxSpawnedEnemiesCount;

        public LevelStorage(Camera camera)
        {
            this.camera = camera;
            itemList = new ArrayList();
            enemiesList = new ArrayList();
            blocksList = new ArrayList();
            enviromentalObjectsList = new ArrayList();
            projectileList = new ArrayList();
            enemyCount = 0;
            maxSpawnedEnemiesCount = 6;
        }
        public void Update()
        {
                foreach (IBlock block in blocksList)
                {
                    block.Update();
                }
                foreach (IItemObjects item in itemList)
                {
                    item.Update();
                }
                foreach (IEnemyObject enemy in enemiesList)
                {
                    if (!enemy.GetRigidBody().IsEnabled)
                    {
                        if ((int)enemy.returnLocation().X - ((int)camera.GetPosition().X + camera.GetWidth()) <= UtilityClass.enableEnemyPixelWidth)
                        {
                            enemy.GetRigidBody().IsEnabled = true;
                        }
                    }
                    enemy.Update();
                }
                foreach (IProjectile projectile in projectileList)
                {
                    if (projectile.Active()) projectile.Update();
                }
                foreach (IEnviromental enviromental in enviromentalObjectsList)
                {
                    enviromental.Update();
                    handleEnemySpawning(enviromental);
                }
        }

        public void Draw(IPlayer player,SpriteBatch spriteBatch,bool hitFlagpole)
        {
            if (!hitFlagpole)
            {
                player.Draw(spriteBatch, camera.GetPosition());
            }

            foreach (IEnviromental enviromental in enviromentalObjectsList)
            {
                enviromental.Draw(spriteBatch, camera.GetPosition());
            }
            foreach (IItemObjects item in itemList)
            {
                item.Draw(spriteBatch, camera.GetPosition());
            }
            foreach (IEnemyObject enemy in enemiesList)
            {
                enemy.Draw(spriteBatch, camera.GetPosition());
            }
            foreach (IBlock block in blocksList)
            {
                block.Draw(spriteBatch, camera.GetPosition());
            }
            foreach (IProjectile projectile in projectileList)
            {
                projectile.Draw(spriteBatch, camera.GetPosition());
            }
        }


        public void handleCollision(IPlayer mario, Game1 game)
        {
            handleMarioCollision((Mario)mario, game);
            foreach (IEnemyObject enemy in enemiesList)
            {
                handleEnemyCollision(enemy);
            }
            foreach (IItemObjects item in itemList)
            {
                if (!item.returnItemType().Equals(ItemType.BoxCoin) && !item.returnItemType().Equals(ItemType.FireFlower) && !item.returnItemType().Equals(ItemType.IceFlower))
                {
                    handleItemCollision(item);
                }
            }
            foreach (IProjectile projectile in projectileList)
            {
                handleProjectileCollision(projectile);
                if (projectile.ReturnProjectileType().Equals(ProjectileType.Fireball))
                {
                    if (((Fireball)projectile).DoneFireBall() && game.fireBallCount < UtilityClass.fireballLimit && projectile.checkForCollisionTestFlag())
                    {
                        game.fireBallCount++;
                    }
                }
                if (projectile.ReturnProjectileType().Equals(ProjectileType.Iceball))
                {
                    if (((Iceball)projectile).DoneIceBall() && game.iceBallCount < UtilityClass.iceballLimit && projectile.checkForCollisionTestFlag())
                    {
                        game.iceBallCount++;
                    }
                }
            }
        }

        private void handleMarioCollision(IPlayer mario,Game1 game)
        {
            LevelCollisionHandlerHelper.handleMarioCollision(mario, game, this);
        }

        private void handleEnemyCollision(IEnemyObject enemy)
        {
            LevelCollisionHandlerHelper.handleEnemyCollision(enemy, this);
        }
        private void handleItemCollision(IItemObjects item)
        {
            LevelCollisionHandlerHelper.handleItemCollision(item, this);
        }

        private void handleProjectileCollision(IProjectile projectile)
        {
            LevelCollisionHandlerHelper.handleProjectileCollision(projectile, this);
        }

        private void handleEnemySpawning(IEnviromental enviromental)
        {
            if (enviromental is EnemySpawner)
            {
                int enemySpawnerRelativeXLocation=((int)((EnemySpawner)enviromental).returnLocation().X - ((int)camera.GetPosition().X + camera.GetWidth()));
                bool spawnEnemyTime=((EnemySpawner)enviromental).timeToSpawnAnEnemy();
                bool inEnableRange = (enemySpawnerRelativeXLocation<= UtilityClass.enableEnemyPixelWidth);
                if (inEnableRange&&spawnEnemyTime&&enemyCount<maxSpawnedEnemiesCount)
                {
                    enemiesList.Add(((EnemySpawner)enviromental).SpawnAnEnemy());
                    increaseEnemyCount();
                }
            }
        }

        public void increaseEnemyCount()
        {
            Console.WriteLine("Inc: "+enemyCount);
            enemyCount++;
        }

        public void decreaseEnemyCount()
        {
            Console.WriteLine("Dec: "+enemyCount);
            enemyCount--;
        }
    }
}
