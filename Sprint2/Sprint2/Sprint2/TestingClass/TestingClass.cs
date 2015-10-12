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
            questionBlockTestBottom();
            questionBlockTestLeft();

            PlatformingBlockTestBottom();
            PlatformingBlockTestLeft();

            GroundBlockTestBottom();
            GroundBlockTestLeft();

            HiddenBlockTestBottom();
            HiddenBlockTestLeft();

            FireFlowerTest();
            CoinTest();
            StarTest();
            SuperMushroomTest();
            OneUpMushroomTest();

            GoombaTestLeft();
            GoombaTestTop();

            KoopaTestLeft();
            KoopaTestTop();

            PipeTestLeft();
            PipeTestTop();
        }

        public void questionBlockTestBottom()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IBlock question = new QuestionBlock(400, 385);
            IMarioState state = ((Mario)mario).State;
            ICollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), question.returnCollisionRectange());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                Console.WriteLine("QuestionBlockTestBottom Passed");
            }
            else
            {
                Console.WriteLine("QuestionBlockTestBottom failed");
            }
        }
        public void questionBlockTestLeft()
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
                Console.WriteLine("QuestionBlockTestLeft Passed");
            }
            else
            {
                Console.WriteLine("QuestionBlockTestLeft failed");
            }
        }

        public void PlatformingBlockTestBottom()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IBlock platform = new PlatformingBlock(400, 385);
            IMarioState state = ((Mario)mario).State;
            ICollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), platform.returnCollisionRectange());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                Console.WriteLine("PlatformBlockBottom Test Passed");
            }
            else
            {
                Console.WriteLine("PlatformBlockBottom failed");
            }
        }

        public void PlatformingBlockTestLeft()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(390, 400);
            IBlock platform = new PlatformingBlock(400, 400);
            IMarioState state = ((Mario)mario).State;
            ICollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), platform.returnCollisionRectange());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                Console.WriteLine("PlatformBlockLeft Test Passed");
            }
            else
            {
                Console.WriteLine("PlatformBlockLeft failed");
            }
        }

        public void GroundBlockTestBottom()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IBlock ground = new GroundBlock(400, 385);
            IMarioState state = ((Mario)mario).State;
            ICollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), ground.returnCollisionRectange());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                Console.WriteLine("GroundBlockBottom Test Passed");
            }
            else
            {
                Console.WriteLine("GroundBlockBottom failed");
            }
        }

        public void GroundBlockTestLeft()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(390, 400);
            IBlock ground = new GroundBlock(400, 400);
            IMarioState state = ((Mario)mario).State;
            ICollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), ground.returnCollisionRectange());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                Console.WriteLine("GroundBlockLeft Test Passed");
            }
            else
            {
                Console.WriteLine("GroundBlockLeft failed");
            }
        }

        public void HiddenBlockTestBottom()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IBlock hidden = new HiddenBlock(400, 385);
            IMarioState state = ((Mario)mario).State;
            ICollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), hidden.returnCollisionRectange());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                Console.WriteLine("HiddenBlockBottom Test Passed");
            }
            else
            {
                Console.WriteLine("HiddenBlockBottom failed");
            }
        }

        public void HiddenBlockTestLeft()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(390, 400);
            IBlock hidden = new HiddenBlock(400, 400);
            IMarioState state = ((Mario)mario).State;
            ICollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), hidden.returnCollisionRectange());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                Console.WriteLine("HiddenBlockLeft Test Passed");
            }
            else
            {
                Console.WriteLine("HiddenBlockLeft failed");
            }
        }

        public void FireFlowerTest()
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
            if (((Mario)mario).Fire && passed)
            {
                Console.WriteLine("FireFlower Test Passed");
            }
            else
            {
                Console.WriteLine("FireFlower failed");
            }
        }
        public void SuperMushroomTest()
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

        public void OneUpMushroomTest()
        {
            bool passed = true;
            ItemSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(390, 400);
            IItemObjects item = new OneUpMushroom(400, 400);
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
            if (passed)
            {
                Console.WriteLine("OneUpMushroom Test Passed");
            }
            else
            {
                Console.WriteLine("OneUpMushroom failed");
            }
        }

        public void CoinTest()
        {
            bool passed = true;
            ItemSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(390, 400);
            IItemObjects coin = new BoxCoin(400, 400);
            IMarioState state = ((Mario)mario).State;
            ICollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), coin.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioItemCollisionHandler itemHandler = new MarioItemCollisionHandler();
            itemHandler.HandleCollision((Mario)mario, coin, side);
            if (passed)
            {
                Console.WriteLine("Coin Test Passed");
            }
            else
            {
                Console.WriteLine("Coin failed");
            }
        }

        public void StarTest()
        {
            bool passed = true;
            ItemSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(390, 400);
            IItemObjects star = new SuperStar(400, 400);
            IMarioState state = ((Mario)mario).State;
            ICollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), star.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioItemCollisionHandler itemHandler = new MarioItemCollisionHandler();
            itemHandler.HandleCollision((Mario)mario, star, side);
            if (((Mario)mario).Star && passed)
            {
                Console.WriteLine("Star Test Passed");
            }
            else
            {
                Console.WriteLine("Star failed");
            }
        }
        public void GoombaTestLeft()
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
                Console.WriteLine("Goomba Left Test Passed");
            }
            else
            {
                Console.WriteLine("Goomba Left Test failed");
            }
        }

        public void GoombaTestTop()
        {
            bool passed = true;
            EnemySpriteFactory.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IEnemyObject enemy = new Goomba(400, 415);
            IMarioState state = ((Mario)mario).State;
            ICollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), enemy.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioEnemyCollisionHandler enemyHandler = new MarioEnemyCollisionHandler();
            enemyHandler.HandleCollision((Mario)mario, enemy, side);
            if (passed)
            {
                Console.WriteLine("Goomba Top Test Passed");
            }
            else
            {
                Console.WriteLine("Goomba Top Test failed");
            }
        }

        public void KoopaTestLeft()
        {
            bool passed = true;
            EnemySpriteFactory.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(390, 400);
            IEnemyObject enemy = new Koopa(400, 400);
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
                Console.WriteLine("Koopa Left Test Passed");
            }
            else
            {
                Console.WriteLine("Koopa Left Test failed");
            }
        }

        public void KoopaTestTop()
        {
            bool passed = true;
            EnemySpriteFactory.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IEnemyObject enemy = new Koopa(400, 415);
            IMarioState state = ((Mario)mario).State;
            ICollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), enemy.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioEnemyCollisionHandler enemyHandler = new MarioEnemyCollisionHandler();
            enemyHandler.HandleCollision((Mario)mario, enemy, side);
            if (passed)
            {
                Console.WriteLine("Koopa Top Test Passed");
            }
            else
            {
                Console.WriteLine("Koopa Top Test failed");
            }
        }

        public void PipeTestTop()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IEnviromental pipe = new Pipe(400, 415);
            IMarioState state = ((Mario)mario).State;
            ICollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), pipe.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                Console.WriteLine("PipeTop Test Passed");
            }
            else
            {
                Console.WriteLine("HiddenBlockBottom failed");
            }
        }

        public void PipeTestLeft()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(390, 400);
            IEnviromental pipe = new Pipe(400, 400);
            IMarioState state = ((Mario)mario).State;
            ICollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), pipe.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                Console.WriteLine("PipeLeft Test Passed");
            }
            else
            {
                Console.WriteLine("PipeLeft failed");
            }
        }

    }
}
