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

        public LevelStorage()
        {
            staticObjectsList = new ArrayList();
            enemiesList = new ArrayList();
            blocksList = new ArrayList();
            enviromentalObjectsList = new ArrayList();
        }
        public void Update(IPlayer mario)
        {            
            foreach (IItemObjects item in staticObjectsList)
            {
                item.Update();
            }
            foreach (IEnemyObject enemy in enemiesList)
            {
                enemy.Update();
            }
            handleCollision((Mario)mario);
        }

        public void Draw(IPlayer player,SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);

            foreach (IItemObjects item in staticObjectsList)
            {
                item.Draw(spriteBatch);
            }
            foreach (IEnemyObject enemy in enemiesList)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (IBlock block in blocksList)
            {
                block.Draw(spriteBatch);
            }
            foreach (IEnviromental enviromental in enviromentalObjectsList)
            {
                enviromental.Draw(spriteBatch);
            }
        }

        private void handleCollision(IPlayer mario)
        {
            IMarioState state = ((Mario)mario).State;
            ((Mario)mario).State.Still();
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side;
            Rectangle floorCheck = ((Mario)mario).returnCollisionRectangle();
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
                    side = collisionDetector.getCollision(mario.returnCollisionRectangle(), block.returnCollisionRectange());
                    blockHandler.handleCollision((Mario)mario, block, side);
                    if (collisionDetector.getCollision(floorCheck, block.returnCollisionRectange()).returnCollisionSide().Equals(CollisionSide.Top))
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

        public bool CheckFloorAgainstBlocks(Rectangle source)
        {
            ICollision side;
            source.Y--;
            CollisionDetector collisionDetector = new CollisionDetector();
            foreach (IBlock block in blocksList)
            {
                if (block.checkForCollisionTestFlag())
                {
                    side = collisionDetector.getCollision(source, block.returnCollisionRectange());
                    if ((side.returnCollisionSide().Equals(CollisionSide.Top))) return true;
                }
            }
            return false;
        }
    }
}
