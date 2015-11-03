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
        }

        public void runTests()
        {
            questionBlockTestBottom();
            questionBlockTestLeft();
            questionBlockTestRight();
            questionBlockTestTop();

            PlatformingBlockTestBottom();
            PlatformingBlockTestLeft();
            PlatformingBlockTestRight();
            PlatformingBlockTestTop();

            GroundBlockTestBottom();
            GroundBlockTestLeft();
            GroundBlockTestRight();
            GroundBlockTestTop();

            HiddenBlockTestBottom();
            HiddenBlockTestLeft();
            HiddenBlockTestRight();
            HiddenBlockTestTop();

            TestFireFlower();
            CoinTest();
            StarTest();
            SuperMushroomTest();
            OneUpMushroomTest();

            GoombaTestLeft();
            GoombaTestRight();
            GoombaTestBottom();
            GoombaTestTop();

            KoopaTestLeft();
            KoopaTestRight();
            KoopaTestTop();
            KoopaTestBottom();

            PipeTestLeft();
            PipeTestTop();
            PipeTestRight();
        }

        public void questionBlockTestBottom()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IBlock question = new Blocks(400, 385,BlockType.Question);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), question.returnCollisionRectangle());
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
            IBlock question = new Blocks(400, 400,BlockType.Question);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), question.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                Console.WriteLine("QuestionBlockTestLeft Passed");
            }
            else
            {
                Console.WriteLine("QuestionBlockTestLeft failed");
            }
        }

        public void questionBlockTestRight()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(410, 400);
            IBlock question = new Blocks(400, 400,BlockType.Question);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), question.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                Console.WriteLine("QuestionBlockTestRight Passed");
            }
            else
            {
                Console.WriteLine("QuestionBlockTestRight failed");
            }
        }

        public void questionBlockTestTop()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IBlock question = new Blocks(400, 415,BlockType.Question);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), question.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                Console.WriteLine("QuestionBlockTestTop Passed");
            }
            else
            {
                Console.WriteLine("QuestionBlockTestTop failed");
            }
        }

        public void PlatformingBlockTestBottom()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IBlock platform = new Blocks(400, 385,BlockType.Platforming);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), platform.returnCollisionRectangle());
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
            IBlock platform = new Blocks(400, 400,BlockType.Platforming);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), platform.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                Console.WriteLine("PlatformBlockLeft Test Passed");
            }
            else
            {
                Console.WriteLine("PlatformBlockLeft failed");
            }
        }

        public void PlatformingBlockTestRight()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(410, 400);
            IBlock platform = new Blocks(400, 400,BlockType.Platforming);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), platform.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                Console.WriteLine("PlatformBlockRight Test Passed");
            }
            else
            {
                Console.WriteLine("PlatformBlockRight failed");
            }
        }

        public void PlatformingBlockTestTop()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IBlock platform = new Blocks(400, 415,BlockType.Platforming);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), platform.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                Console.WriteLine("PlatformBlockTop Test Passed");
            }
            else
            {
                Console.WriteLine("PlatformBlockTop failed");
            }
        }

        public void GroundBlockTestBottom()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IBlock ground = new Blocks(400, 385,BlockType.Ground);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), ground.returnCollisionRectangle());
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
            IBlock ground = new Blocks(400, 400,BlockType.Ground);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), ground.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                Console.WriteLine("GroundBlockLeft Test Passed");
            }
            else
            {
                Console.WriteLine("GroundBlockLeft failed");
            }
        }

        public void GroundBlockTestRight()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(410, 400);
            IBlock ground = new Blocks(400, 400,BlockType.Ground);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), ground.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                Console.WriteLine("GroundBlockRight Test Passed");
            }
            else
            {
                Console.WriteLine("GroundBlockRight failed");
            }
        }

        public void GroundBlockTestTop()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IBlock ground = new Blocks(400, 415,BlockType.Ground);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), ground.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                Console.WriteLine("GroundBlockTop Test Passed");
            }
            else
            {
                Console.WriteLine("GroundBlockTop failed");
            }
        }

        public void HiddenBlockTestBottom()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IBlock hidden = new Blocks(400, 385,BlockType.Hidden);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), hidden.returnCollisionRectangle());
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
            IBlock hidden = new Blocks(400, 400,BlockType.Hidden);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), hidden.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                Console.WriteLine("HiddenBlockLeft Test Passed");
            }
            else
            {
                Console.WriteLine("HiddenBlockLeft failed");
            }
        }

        public void HiddenBlockTestRight()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(410, 400);
            IBlock hidden = new Blocks(400, 400,BlockType.Hidden);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), hidden.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                Console.WriteLine("HiddenBlockRight Test Passed");
            }
            else
            {
                Console.WriteLine("HiddenBlockRight failed");
            }
        }

        public void HiddenBlockTestTop()
        {
            bool passed = true;
            BlockSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IBlock hidden = new Blocks(400, 415,BlockType.Hidden);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), hidden.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                Console.WriteLine("HiddenBlockTop Test Passed");
            }
            else
            {
                Console.WriteLine("HiddenBlockTop failed");
            }
        }

        
        public void SuperMushroomTest()
        {
            bool passed = true;
            ItemSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(390, 400);
            IItemObjects item = new SuperMushroom(400, 400);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), item.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioItemCollisionHandler.handleCollision((Mario)mario, item, side);
            if (passed)
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
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), item.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioItemCollisionHandler.handleCollision((Mario)mario, item, side);
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
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), coin.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioItemCollisionHandler.handleCollision((Mario)mario, coin, side);
            if (passed)
            {
                Console.WriteLine("Coin Test Passed");
            }
            else
            {
                Console.WriteLine("Coin failed");
            }
        }

        public void TestFireFlower()
        {
            bool passed = true;
            ItemSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(395, 400);
            IItemObjects fireFlower = new FireFlower(400, 400);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), fireFlower.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioItemCollisionHandler.handleCollision((Mario)mario, fireFlower, side);
            if (passed)
            {
                Console.WriteLine("FireFlower Test Passed");
            }
            else
            {
                Console.WriteLine("FireFlower failed");
            }
        }
        public void StarTest()
        {
            bool passed = true;
            ItemSpriteTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(390, 400);
            IItemObjects star = new SuperStar(400, 400);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), star.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioItemCollisionHandler.handleCollision((Mario)mario, star, side);
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
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), enemy.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioEnemyCollisionHandler.handleCollision((Mario)mario, enemy, side);
            if (((Mario)mario).StateStatus().Equals(MarioState.Die) && passed)
            {
                Console.WriteLine("Goomba Left Test Passed");
            }
            else
            {
                Console.WriteLine("Goomba Left Test failed");
            }
        }

        public void GoombaTestRight()
        {
            bool passed = true;
            EnemySpriteFactory.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(410, 400);
            IEnemyObject enemy = new Goomba(400, 400);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), enemy.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioEnemyCollisionHandler.handleCollision((Mario)mario, enemy, side);
            if (((Mario)mario).StateStatus().Equals(MarioState.Die) && passed)
            {
                Console.WriteLine("Goomba Right Test Passed");
            }
            else
            {
                Console.WriteLine("Goomba Right Test failed");
            }
        }

        public void GoombaTestTop()
        {
            bool passed = true;
            EnemySpriteFactory.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IEnemyObject enemy = new Goomba(400, 415);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), enemy.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioEnemyCollisionHandler.handleCollision((Mario)mario, enemy, side);
            if (passed)
            {
                Console.WriteLine("Goomba Top Test Passed");
            }
            else
            {
                Console.WriteLine("Goomba Top Test failed");
            }
        }

        public void GoombaTestBottom()
        {
            bool passed = true;
            EnemySpriteFactory.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IEnemyObject enemy = new Goomba(400, 385);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), enemy.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioEnemyCollisionHandler.handleCollision((Mario)mario, enemy, side);
            if (((Mario)mario).StateStatus().Equals(MarioState.Die) && passed)
            {
                Console.WriteLine("Goomba Bottom Test Passed");
            }
            else
            {
                Console.WriteLine("Goomba Bottom Test failed");
            }
        }

        public void KoopaTestLeft()
        {
            bool passed = true;
            EnemySpriteFactory.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(390, 400);
            IEnemyObject enemy = new Koopa(400, 400);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), enemy.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Left))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioEnemyCollisionHandler.handleCollision((Mario)mario, enemy, side);
            if (((Mario)mario).StateStatus().Equals(MarioState.Die) && passed)
            {
                Console.WriteLine("Koopa Left Test Passed");
            }
            else
            {
                Console.WriteLine("Koopa Left Test failed");
            }
        }

        public void KoopaTestRight()
        {
            bool passed = true;
            EnemySpriteFactory.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(410, 400);
            IEnemyObject enemy = new Koopa(400, 400);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), enemy.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioEnemyCollisionHandler.handleCollision((Mario)mario, enemy, side);
            if (((Mario)mario).StateStatus().Equals(MarioState.Die) && passed)
            {
                Console.WriteLine("Koopa Right Test Passed");
            }
            else
            {
                Console.WriteLine("Koopa Right Test failed");
            }
        }

        public void KoopaTestTop()
        {
            bool passed = true;
            EnemySpriteFactory.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IEnemyObject enemy = new Koopa(400, 415);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), enemy.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Top))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioEnemyCollisionHandler.handleCollision((Mario)mario, enemy, side);
            if (passed)
            {
                Console.WriteLine("Koopa Top Test Passed");
            }
            else
            {
                Console.WriteLine("Koopa Top Test failed");
            }
        }

        public void KoopaTestBottom()
        {
            bool passed = true;
            EnemySpriteFactory.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IEnemyObject enemy = new Koopa(400, 385);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), enemy.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Bottom))
            {
                passed = true;
            }
            else
            {
                passed = false;
            }
            MarioEnemyCollisionHandler.handleCollision((Mario)mario, enemy, side);
            if (((Mario)mario).StateStatus().Equals(MarioState.Die) && passed)
            {
                Console.WriteLine("Koopa Bottom Test Passed");
            }
            else
            {
                Console.WriteLine("Koopa Bottom Test failed");
            }
        }

        public void PipeTestTop()
        {
            bool passed = true;
            MiscGameObjectTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(400, 400);
            IEnviromental pipe = new Pipe(400, 415);
            CollisionDetector collisionDetector = new CollisionDetector();
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
            MiscGameObjectTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(390, 400);
            IEnviromental pipe = new Pipe(400, 400);
            CollisionDetector collisionDetector = new CollisionDetector();
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
        public void PipeTestRight()
        {
            bool passed = true;
            MiscGameObjectTextureStorage.Load(game.Content);
            MarioSpriteFactory.Load(game.Content);
            IPlayer mario = new Mario(410, 400);
            IEnviromental pipe = new Pipe(400, 400);
            CollisionDetector collisionDetector = new CollisionDetector();
            ICollision side = collisionDetector.getCollision(mario.returnCollisionRectangle(), pipe.returnCollisionRectangle());
            if (passed && side.returnCollisionSide().Equals(CollisionSide.Right))
            {
                Console.WriteLine("PipeRight Test Passed");
            }
            else
            {
                Console.WriteLine("PipeRight failed");
            }
        }

    }
}
