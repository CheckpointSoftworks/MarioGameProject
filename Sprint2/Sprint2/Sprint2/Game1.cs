using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Sprint2
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public IController keyboard;
        public IController gamepad;
        public IPlayer mario;
        private LevelLoader loader;
        private Texture2D background;
        private Rectangle mainframe;
        public ICommand keyboardNotPressed;
        private TestingClass tester;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            tester = new TestingClass(this);
            keyboard = new KeyboardController();
            gamepad = new GamepadController(this);
            keyboardNotPressed = new KeyNotPressed(this); 
            loader= new LevelLoader("Level.xml");
            mainframe = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            base.Initialize();
            tester.runTests();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            BlockSpriteTextureStorage.Load(this.Content);
            ItemSpriteTextureStorage.Load(this.Content);
            EnemySpriteFactory.Load(this.Content);
            MiscGameObjectTextureStorage.Load(this.Content);
            MarioSpriteFactory.Load(this.Content);
            background = Content.Load<Texture2D>("Background");

            loader.LoadLevel();
            LoadKeyBoardCommands();
            mario = loader.player;
        }

        private void LoadKeyBoardCommands()
        {

            ((KeyboardController)keyboard).RegisterCommand(Keys.W, new UpCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.Up, new UpCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.S, new DownCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.Down, new DownCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.A, new LeftCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.Left, new LeftCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.D, new RightCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.Right, new RightCommand(this));
            ((KeyboardController)keyboard).RegisterDiagonalCommands(this);
        }


        protected override void UnloadContent()
        {
            // Not Yet Needed in the scope of the project
        }


        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            keyboard.Update();
            gamepad.Update();
            keyboardNotPressed.Execute();
            mario.Update();
            handleCollision();
            foreach (IItemObjects item in loader.staticObjectsList)
            {
                item.Update();
            } 

            base.Update(gameTime);
        }

        private void handleCollision()
        {
            IMarioState state = ((Mario)mario).State;
            ((Mario)mario).State.Still();
            ICollisionDetector collisionDetector = new CollisionDetector();
            ICollision side;
            MarioBlockCollisionHandler blockHandler = new MarioBlockCollisionHandler();
            MarioEnemyCollisionHandler enemyHandler = new MarioEnemyCollisionHandler();
            MarioItemCollisionHandler itemHandler = new MarioItemCollisionHandler();
            MarioPipeCollisionHandler pipeHandler = new MarioPipeCollisionHandler();
            foreach (IBlock block in loader.blocksList)
            {
                if (block.checkForCollisionTestFlag())
                {
                    side =collisionDetector.getCollision(mario.returnCollisionRectangle(), block.returnCollisionRectange());
                    blockHandler.HandleCollision((Mario)mario, block, side);
                }
            }
            foreach (IEnemyObject enemy in loader.enemiesList)
            {
                side=collisionDetector.getCollision(mario.returnCollisionRectangle(), enemy.returnCollisionRectangle());
                enemyHandler.HandleCollision((Mario)mario, enemy, side);
            }
            foreach (IItemObjects item in loader.staticObjectsList)
            {
                if (item.checkForCollisionTestFlag())
                {
                    side=collisionDetector.getCollision(mario.returnCollisionRectangle(), item.returnCollisionRectangle());
                    itemHandler.HandleCollision((Mario)mario, item, side);
                }
            }
            foreach (IEnviromental enviromental in loader.enviromentalObjectsList)
            {
                side=collisionDetector.getCollision(mario.returnCollisionRectangle(), enviromental.returnCollisionRectangle());
                pipeHandler.HandleCollision((Mario)mario, enviromental,side);
            }
            ((Mario)mario).State = state;
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(background, mainframe, Color.White);
            spriteBatch.End();

            mario.Draw(spriteBatch);

            foreach (IItemObjects item in loader.staticObjectsList)
            {
                item.Draw(spriteBatch);
            }
            foreach (IEnemyObject enemy in loader.enemiesList)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (IBlock block in loader.blocksList)
            {
                block.Draw(spriteBatch);
            }
            foreach (IEnviromental enviromental in loader.enviromentalObjectsList)
            {
                enviromental.Draw(spriteBatch);
            }

            base.Draw(gameTime);

        }
    }
}
