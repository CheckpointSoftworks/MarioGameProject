using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public static class LevelCollisionHandlerHelper
    {
        public static void handleMarioCollision(IPlayer mario,Game1 game,LevelStorage storage)
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
            foreach (IBlock block in storage.blocksList)
            {
                if (block.checkForCollisionTestFlag())
                {
                    side = collisionDetector.getCollision(mario.returnCollisionRectangle(), block.returnCollisionRectangle());
                    blockHandler.handleCollision((Mario)mario, block, side, game);
                    if (collisionDetector.getCollision(floorCheck, block.returnCollisionRectangle()).returnCollisionSide().Equals(CollisionSide.Top))
                    {
                        ((Mario)mario).rigidbody.Floored = true;
                    }
                }

            }
            foreach (IEnemyObject enemy in storage.enemiesList)
            {
                side = collisionDetector.getCollision(mario.returnCollisionRectangle(), enemy.returnCollisionRectangle());
                enemyHandler.handleCollision((Mario)mario, enemy, side);
            }
            foreach (IItemObjects item in storage.itemList)
            {
                if (item.checkForCollisionTestFlag())
                {
                    side = collisionDetector.getCollision(mario.returnCollisionRectangle(), item.returnCollisionRectangle());
                    itemHandler.handleCollision((Mario)mario, item, side);
                }
            }
            foreach (IEnviromental enviromental in storage.enviromentalObjectsList)
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

        public static void handleEnemyCollision(IEnemyObject enemy, LevelStorage storage)
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
            foreach (IBlock block in storage.blocksList)
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
            foreach (IEnviromental enviromental in storage.enviromentalObjectsList)
            {
                side = collisionDetector.getCollision(enemy.returnCollisionRectangle(), enviromental.returnCollisionRectangle());
                enemyEnviroHandler.handleCollision(enemy, enviromental, side);
            }
            foreach (IEnemyObject secondEnemy in storage.enemiesList)
            {
                if (!enemy.Equals(secondEnemy))
                {
                    side = collisionDetector.getCollision(enemy.returnCollisionRectangle(), secondEnemy.returnCollisionRectangle());
                    enemyEnemyHandler.handleCollision(enemy, secondEnemy, side);
                }
            }
            foreach (IProjectile projectile in storage.projectileList)
            {
                side = collisionDetector.getCollision(enemy.returnCollisionRectangle(), projectile.returnCollisionRectangle());
                enemyProjHandler.handleCollision(enemy, projectile, side);
            }
        }

        public static void handleItemCollision(IItemObjects item,LevelStorage storage)
        {
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side;
            Rectangle floorCheck;
            floorCheck = item.returnCollisionRectangle();
            floorCheck.Y++;
            ItemBlockCollisionHandler itemBlockHandler = new ItemBlockCollisionHandler();
            ItemEnvriomentalCollisionHandler itemEnviroHandler = new ItemEnvriomentalCollisionHandler();
            item.RigidBody().Floored = false;
            foreach (IBlock block in storage.blocksList)
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
            foreach (IEnviromental enviromental in storage.enviromentalObjectsList)
            {
                side = collisionDetector.getCollision(item.returnCollisionRectangle(), enviromental.returnCollisionRectangle());
                itemEnviroHandler.handleCollision(item, enviromental, side);
            }
        }

        public static void handleProjectileCollision(IProjectile projectile,LevelStorage storage)
        {
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side;
            Rectangle floorCheck;
            floorCheck = projectile.returnCollisionRectangle();
            floorCheck.Y++;
            ProjectileBlockCollisionHandler projBlockHandler = new ProjectileBlockCollisionHandler();
            ProjectileEnviromentalCollisionHandler projEnviroHandler = new ProjectileEnviromentalCollisionHandler();
            projectile.RigidBody().Floored = false;
            foreach (IBlock block in storage.blocksList)
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
            foreach (IEnviromental enviromental in storage.enviromentalObjectsList)
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
