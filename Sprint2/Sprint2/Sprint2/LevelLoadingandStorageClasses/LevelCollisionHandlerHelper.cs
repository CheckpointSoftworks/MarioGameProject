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
            ((Mario)mario).rigidbody.Floored = false;
            foreach (IBlock block in storage.blocksList)
            {
                if (block.checkForCollisionTestFlag())
                {
                    side = collisionDetector.getCollision(mario.returnCollisionRectangle(), block.returnCollisionRectangle());
                    MarioBlockCollisionHandler.handleCollision((Mario)mario, block, side, game);
                    if (collisionDetector.getCollision(floorCheck, block.returnCollisionRectangle()).returnCollisionSide().Equals(CollisionSide.Top))
                    {
                        ((Mario)mario).rigidbody.Floored = true;
                        floorCheck.Y++;
                    }
                    if (!side.returnCollisionSide().Equals(CollisionSide.None))
                    {
                        Console.WriteLine("Collision: " + collisionDetector.getCollision(floorCheck, block.returnCollisionRectangle()).returnCollisionSide());
                    }
                }

            }
            foreach (IEnemyObject enemy in storage.enemiesList)
            {
                side = collisionDetector.getCollision(mario.returnCollisionRectangle(), enemy.returnCollisionRectangle());
                MarioEnemyCollisionHandler.handleCollision((Mario)mario, enemy, side);
            }
            foreach (IItemObjects item in storage.itemList)
            {
                if (item.checkForCollisionTestFlag())
                {
                    side = collisionDetector.getCollision(mario.returnCollisionRectangle(), item.returnCollisionRectangle());
                    MarioItemCollisionHandler.handleCollision((Mario)mario, item, side);
                }
            }
            foreach (IEnviromental enviromental in storage.enviromentalObjectsList)
            {
                side = collisionDetector.getCollision(mario.returnCollisionRectangle(), enviromental.returnCollisionRectangle());
                MarioPipeCollisionHandler.handleCollision((Mario)mario, enviromental, side);
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
            enemy.GetRigidBody().Floored = false;
            foreach (IBlock block in storage.blocksList)
            {
                if (block.checkForCollisionTestFlag())
                {
                    side = collisionDetector.getCollision(enemy.returnCollisionRectangle(), block.returnCollisionRectangle());
                    EnemyBlockCollisionHandler.handleCollision(enemy, block, side);
                }
                if (collisionDetector.getCollision(floorCheck, block.returnCollisionRectangle()).returnCollisionSide().Equals(CollisionSide.Top))
                {
                    enemy.GetRigidBody().Floored = true;
                }
            }
            foreach (IEnviromental enviromental in storage.enviromentalObjectsList)
            {
                side = collisionDetector.getCollision(enemy.returnCollisionRectangle(), enviromental.returnCollisionRectangle());
                EnemyEnviromentalCollisionHandler.handleCollision(enemy, enviromental, side);
            }
            foreach (IEnemyObject secondEnemy in storage.enemiesList)
            {
                if (!enemy.Equals(secondEnemy))
                {
                    side = collisionDetector.getCollision(enemy.returnCollisionRectangle(), secondEnemy.returnCollisionRectangle());
                    EnemyEnemyCollisionHandler.handleCollision(enemy, secondEnemy, side);
                }
            }
            foreach (IProjectile projectile in storage.projectileList)
            {
                side = collisionDetector.getCollision(enemy.returnCollisionRectangle(), projectile.returnCollisionRectangle());
                EnemyProjectileCollisionHandler.handleCollision(enemy, projectile, side);
            }
        }

        public static void handleItemCollision(IItemObjects item,LevelStorage storage)
        {
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side;
            Rectangle floorCheck;
            floorCheck = item.returnCollisionRectangle();
            floorCheck.Y++;
            item.RigidBody().Floored = false;
            foreach (IBlock block in storage.blocksList)
            {

                if (block.checkForCollisionTestFlag())
                {
                    side = collisionDetector.getCollision(item.returnCollisionRectangle(), block.returnCollisionRectangle());
                    ItemBlockCollisionHandler.handleCollision(item, block, side);
                }
                if (collisionDetector.getCollision(floorCheck, block.returnCollisionRectangle()).returnCollisionSide().Equals(CollisionSide.Top))
                {
                    item.RigidBody().Floored = true;
                }
            }
            foreach (IEnviromental enviromental in storage.enviromentalObjectsList)
            {
                side = collisionDetector.getCollision(item.returnCollisionRectangle(), enviromental.returnCollisionRectangle());
                ItemEnvriomentalCollisionHandler.handleCollision(item, enviromental, side);
            }
        }

        public static void handleProjectileCollision(IProjectile projectile,LevelStorage storage)
        {
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side;
            Rectangle floorCheck;
            floorCheck = projectile.returnCollisionRectangle();
            floorCheck.Y++;
            projectile.RigidBody().Floored = false;
            foreach (IBlock block in storage.blocksList)
            {
                if (block.checkForCollisionTestFlag())
                {
                    
                    side = collisionDetector.getCollision(projectile.returnCollisionRectangle(), block.returnCollisionRectangle());
                    ProjectileBlockCollisionHandler.handleCollision(projectile, block, side);
                }
                if (collisionDetector.getCollision(floorCheck, block.returnCollisionRectangle()).returnCollisionSide().Equals(CollisionSide.Top))
                {
                    projectile.RigidBody().Floored = true;
                }
            }
            foreach (IEnviromental enviromental in storage.enviromentalObjectsList)
            {
                side = collisionDetector.getCollision(projectile.returnCollisionRectangle(), enviromental.returnCollisionRectangle());
                ProjectileEnviromentalCollisionHandler.handleCollision(projectile, enviromental, side);
                if (collisionDetector.getCollision(floorCheck, enviromental.returnCollisionRectangle()).returnCollisionSide().Equals(CollisionSide.Top))
                {
                    projectile.RigidBody().Floored = true;
                }
            }
        }
    }
}
