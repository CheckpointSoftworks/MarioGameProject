using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Sprint2
{
    public class TestingClass
    {
        private Game1 game;

        public TestingClass(Game1 game)
        {
            this.game = game;
            MiscGameObjectTextureStorage.Load(game.Content);
        }

        public void runTests()
        {
            questionBlockTest1();
            questionBlockTest2();
            fireFlowerTest();
            superMushroomTest();
            goombaTest1();
        }

        public void questionBlockTest1()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IBlock question = new QuestionBlock(400, 385);
            IMarioState state = ((Mario)mario).State;
            ICollisionDetector collisionDetector = new CollisionDetector();
            ICollision side=collisionDetector.getCollision(mario.returnCollisionRectangle(),question.returnCollisionRectange());
            if (passed&&side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                Console.WriteLine("QuestionBlockTest1 Passed");
            }
            else
            {
                Console.WriteLine("QuestionBlockTest1 failed");
            }
        }
        public void questionBlockTest2()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(390, 400);
            IBlock question = new QuestionBlock(400, 400);
            IMarioState state = ((Mario)mario).State;
            ICollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), question.returnCollisionRectange());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                Console.WriteLine("QuestionBlockTest2 Passed");
            }
            else
            {
                Console.WriteLine("QuestionBlockTest2 failed");
            }
        }
        public void fireFlowerTest()
        {
            bool passed = true;
            ItemSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(390, 400);
            IItemObjects fireFlower = new FireFlower(400, 400);
            IMarioState state = ((Mario)mario).State;
            ICollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), fireFlower.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioItemCollisionHandler itemHandler = new MarioItemCollisionHandler();
            itemHandler.HandleCollision((Mario)mario, fireFlower, side);
            if(((Mario)mario).Fire&&passed)
            {
                Console.WriteLine("FireFlower Test Passed");
            }
            else
            {
                Console.WriteLine("FireFlower failed");
            }
        }
        public void superMushroomTest()
        {
            bool passed = true;
            ItemSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(390, 400);
            IItemObjects item = new SuperMushroom(400, 400);
            IMarioState state = ((Mario)mario).State;
            ICollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), item.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioItemCollisionHandler itemHandler = new MarioItemCollisionHandler();
            itemHandler.HandleCollision((Mario)mario, item, side);
            if ((!((Mario)mario).Small) && passed)
            {
                Console.WriteLine("SuperMushroom Test Passed");
            }
            else
            {
                Console.WriteLine("SuperMushroom failed");
            }
        }
        public void goombaTest1()
        {
            bool passed = true;
            EnemySpriteFactory.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(390, 400);
            IEnemyObject enemy = new Goomba(400, 400);
            IMarioState state = ((Mario)mario).State;
            ICollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), enemy.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioEnemyCollisionHandler enemyHandler = new MarioEnemyCollisionHandler();
            enemyHandler.HandleCollision((Mario)mario, enemy, side);
            if ((((Mario)mario).IsDying) && passed)
            {
                Console.WriteLine("Goomba 1 Test Passed");
            }
            else
            {
                Console.WriteLine("Goomba 2 Test failed");
            }
        }
    }
}
