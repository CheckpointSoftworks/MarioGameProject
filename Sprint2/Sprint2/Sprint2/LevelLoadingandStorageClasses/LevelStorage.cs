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

        public LevelStorage(Camera camera)
        {
            this.camera = camera;
            itemList = new ArrayList();
            enemiesList = new ArrayList();
            blocksList = new ArrayList();
            enviromentalObjectsList = new ArrayList();
            projectileList = new ArrayList();
        }
        public void Update(IPlayer mario,Game1 game)
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
                    if ((int)enemy.returnLocation().X - ((int)camera.GetPosition().X + camera.GetWidth()) <= 10)
                    {
                        enemy.GetRigidBody().IsEnabled = true;
                    }
                }
                enemy.Update();
            }
            foreach (IProjectile projectile in projectileList)
            {
                projectile.Update();
            }
            foreach (IEnviromental enviromental in enviromentalObjectsList)
            {
                enviromental.Update();
            }
            handleCollision(mario, game);
        }

        public void Draw(IPlayer player,SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch, camera.GetPosition());

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

        private void handleCollision(IPlayer mario, Game1 game)
        {
            handleMarioCollision((Mario)mario, game);
            foreach (IEnemyObject enemy in enemiesList)
            {
                handleEnemyCollision(enemy);
            }
            foreach (IItemObjects item in itemList)
            {
                if (!item.returnItemType().Equals(ItemType.Coin) && !item.returnItemType().Equals(ItemType.FireFlower))
                {
                    handleItemCollision(item);
                }
            }
            foreach (IProjectile projectile in projectileList)
            {
                handleProjectileCollision(projectile);
                if (((Fireball)projectile).DoneFireBall() && game.fireBallCount < 10 && projectile.checkForCollisionTestFlag())
                {
                    game.fireBallCount++;
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
    }
}
