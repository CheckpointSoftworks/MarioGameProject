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
        public IPlayer player { get; set; }
        public ArrayList itemList;
        public ArrayList enemiesList;
        public ArrayList blocksList;
        public ArrayList enviromentalObjectsList;
        public ArrayList projectileList;
        public Camera camera;

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
            handleMarioCollision((Mario)mario,game);
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
                if (((Fireball)projectile).DoneFireBall()&&game.fireBallCount<2&&projectile.checkForCollisionTestFlag())
                {
                    game.fireBallCount++;
                }
            }
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

        private void handleMarioCollision(IPlayer mario,Game1 game)
        {
            IMarioState state = ((Mario)mario).State;
            ((Mario)mario).State.Still();
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side;
            Rectangle floorCheck;
            floorCheck = mario.returnCollisionRectangle();
            floorCheck.Y++;
            MarioBlockCollisionHandler blockHandler = new MarioBlockCollisionHandler();
            MarioEnemyCollisionHandler enemyHandler = new MarioEnemyCollisionHandler();
            MarioItemCollisionHandler itemHandler = new MarioItemCollisionHandler();
            MarioPipeCollisionHandler pipeHandler = new MarioPipeCollisionHandler();
            ((Mario)mario).rigidbody.Floored = false;
            foreach (IBlock block in blocksList)
            {
                if (block.checkForCollisionTestFlag())
                {
                    side = collisionDetector.getCollision(mario.returnCollisionRectangle(), block.returnCollisionRectangle());
                    blockHandler.handleCollision((Mario)mario, block, side,game);
                    if (collisionDetector.getCollision(floorCheck, block.returnCollisionRectangle()).returnCollisionSide().Equals(CollisionSide.Top))
                    {
                        ((Mario)mario).rigidbody.Floored = true;
                    }
                }

            }
            foreach (IEnemyObject enemy in enemiesList)
            {
                side = collisionDetector.getCollision(mario.returnCollisionRectangle(), enemy.returnCollisionRectangle());
                enemyHandler.handleCollision((Mario)mario, enemy, side);
            }
            foreach (IItemObjects item in itemList)
            {
                if (item.checkForCollisionTestFlag())
                {
                    side = collisionDetector.getCollision(mario.returnCollisionRectangle(), item.returnCollisionRectangle());
                    itemHandler.handleCollision((Mario)mario, item, side);
                }
            }
            foreach (IEnviromental enviromental in enviromentalObjectsList)
            {
                side = collisionDetector.getCollision(mario.returnCollisionRectangle(), enviromental.returnCollisionRectangle());
                pipeHandler.handleCollision((Mario)mario, enviromental, side);
                if (collisionDetector.getCollision(floorCheck, enviromental.returnCollisionRectangle()).returnCollisionSide().Equals(CollisionSide.Top))
                {
                    ((Mario)mario).rigidbody.Floored = true;
                }
            }
            ((Mario)mario).State = state;
        }

        private void handleEnemyCollision(IEnemyObject enemy)
        {
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side;
            Rectangle floorCheck;
            floorCheck = enemy.returnCollisionRectangle();
            floorCheck.Y++;
            EnemyBlockCollisionHandler enemyBlockHandler = new EnemyBlockCollisionHandler();
            EnemyEnviromentalCollisionHandler enemyEnviroHandler = new EnemyEnviromentalCollisionHandler();
            EnemyEnemyCollisionHandler enemyEnemyHandler = new EnemyEnemyCollisionHandler();
            EnemyProjectileCollisionHandler enemyProjHandler = new EnemyProjectileCollisionHandler();
            enemy.GetRigidBody().Floored = false;
            foreach (IBlock block in blocksList)
            {
                if (block.checkForCollisionTestFlag())
                {
                    side = collisionDetector.getCollision(enemy.returnCollisionRectangle(), block.returnCollisionRectangle());
                    enemyBlockHandler.handleCollision(enemy, block, side);
                }
                if (collisionDetector.getCollision(floorCheck, block.returnCollisionRectangle()).returnCollisionSide().Equals(CollisionSide.Top))
                {
                    enemy.GetRigidBody().Floored = true;
                }
            }
            foreach (IEnviromental enviromental in enviromentalObjectsList)
            {
                side = collisionDetector.getCollision(enemy.returnCollisionRectangle(), enviromental.returnCollisionRectangle());
                enemyEnviroHandler.handleCollision(enemy, enviromental, side);
            }
            foreach (IEnemyObject secondEnemy in enemiesList)
            {
                if (!enemy.Equals(secondEnemy))
                {
                    side = collisionDetector.getCollision(enemy.returnCollisionRectangle(), secondEnemy.returnCollisionRectangle());
                    enemyEnemyHandler.handleCollision(enemy, secondEnemy, side);
                }
            }
            foreach (IProjectile projectile in projectileList)
            {
                side = collisionDetector.getCollision(enemy.returnCollisionRectangle(), projectile.returnCollisionRectangle());
                enemyProjHandler.handleCollision(enemy, projectile, side);
            }
        }
        private void handleItemCollision(IItemObjects item)
        {
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side;
            Rectangle floorCheck;
            floorCheck = item.returnCollisionRectangle();
            floorCheck.Y++;
            ItemBlockCollisionHandler itemBlockHandler = new ItemBlockCollisionHandler();
            ItemEnvriomentalCollisionHandler itemEnviroHandler = new ItemEnvriomentalCollisionHandler();
            item.RigidBody().Floored = false; 
            foreach (IBlock block in blocksList)
            {

                if (block.checkForCollisionTestFlag())
                {
                    side = collisionDetector.getCollision(item.returnCollisionRectangle(), block.returnCollisionRectangle());
                    itemBlockHandler.handleCollision(item, block, side);
                }
                if (collisionDetector.getCollision(floorCheck, block.returnCollisionRectangle()).returnCollisionSide().Equals(CollisionSide.Top))
                {
                   item.RigidBody().Floored = true;
                }
            }
            foreach (IEnviromental enviromental in enviromentalObjectsList)
            {
                side = collisionDetector.getCollision(item.returnCollisionRectangle(), enviromental.returnCollisionRectangle());
                itemEnviroHandler.handleCollision(item, enviromental, side);
            }
        }

        private void handleProjectileCollision(IProjectile projectile)
        {
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side;
            Rectangle floorCheck;
            floorCheck = projectile.returnCollisionRectangle();
            floorCheck.Y++;
            ProjectileBlockCollisionHandler projBlockHandler = new ProjectileBlockCollisionHandler();
            ProjectileEnviromentalCollisionHandler projEnviroHandler = new ProjectileEnviromentalCollisionHandler();
            projectile.RigidBody().Floored = false;
            foreach (IBlock block in blocksList)
            {
                if (block.checkForCollisionTestFlag())
                {
                    
                    side = collisionDetector.getCollision(projectile.returnCollisionRectangle(), block.returnCollisionRectangle());
                    projBlockHandler.handleCollision(projectile, block, side);
                }
                if (collisionDetector.getCollision(floorCheck, block.returnCollisionRectangle()).returnCollisionSide().Equals(CollisionSide.Top))
                {
                    projectile.RigidBody().Floored = true;
                }
            }
            foreach (IEnviromental enviromental in enviromentalObjectsList)
            {
                side = collisionDetector.getCollision(projectile.returnCollisionRectangle(), enviromental.returnCollisionRectangle());
                projEnviroHandler.handleCollision(projectile, enviromental, side);
                if (collisionDetector.getCollision(floorCheck, enviromental.returnCollisionRectangle()).returnCollisionSide().Equals(CollisionSide.Top))
                {
                    projectile.RigidBody().Floored = true;
                }
            }
        }
    }
}
