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
        public ArrayList staticObjectsList;
        public ArrayList enemiesList;
        public ArrayList blocksList;
        public ArrayList enviromentalObjectsList;
        public Camera camera;

        public LevelStorage(Camera camera)
        {
            this.camera = camera;
            staticObjectsList = new ArrayList();
            enemiesList = new ArrayList();
            blocksList = new ArrayList();
            enviromentalObjectsList = new ArrayList();
        }
        public void Update(IPlayer mario,Game1 game)
        {
            foreach (IBlock block in blocksList)
            {
                block.Update();
            }
            foreach (IItemObjects item in staticObjectsList)
            {
                item.Update();
            }
            foreach (IEnemyObject enemy in enemiesList)
            {
                enemy.Update();
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
        }

        public void Draw(IPlayer player,SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch, camera.GetPosition());

            foreach (IItemObjects item in staticObjectsList)
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
            foreach (IEnviromental enviromental in enviromentalObjectsList)
            {
                enviromental.Draw(spriteBatch, camera.GetPosition());
            }
            foreach (IBlock block in blocksList)
            {
                block.Update();
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
            foreach (IItemObjects item in staticObjectsList)
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
        }
    }
}
