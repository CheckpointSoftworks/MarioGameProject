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

        private ICommand keyboardNotPressed;
        private LevelLoader loader;
        private LevelStorage levelStore;
        private Texture2D background;
        private Rectangle mainframe;
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
            levelStore = new LevelStorage();

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

            loader.LoadLevel(levelStore);
            LoadKeyBoardCommands();
            mario = levelStore.player;
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
            
        }


        protected override void Update(GameTime gameTime)
        {
            keyboard.Update();
            gamepad.Update();
            keyboardNotPressed.Execute();
            mario.Update();
            foreach (IItemObjects item in levelStore.staticObjectsList)
            {
                item.Update();
            }
            foreach (IEnemyObject enemy in levelStore.enemiesList)
            {
                enemy.Update();
            }
            levelStore.Update(mario);
            base.Update(gameTime);
        }

       

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(background, mainframe, Color.White);
            spriteBatch.End();

            mario.Draw(spriteBatch);

            foreach (IItemObjects item in levelStore.staticObjectsList)
            {
                item.Draw(spriteBatch);
            }
            foreach (IEnemyObject enemy in levelStore.enemiesList)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (IBlock block in levelStore.blocksList)
            {
                block.Draw(spriteBatch);
            }
            foreach (IEnviromental enviromental in levelStore.enviromentalObjectsList)
            {
                enviromental.Draw(spriteBatch);
            }

            base.Draw(gameTime);

        }
    }
}
