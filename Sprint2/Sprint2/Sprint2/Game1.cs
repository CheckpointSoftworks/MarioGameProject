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
        public GraphicsDeviceManager graphics{get;set;}
        public SpriteBatch spriteBatch{get;set;}

        public IController keyboard { get; set; }
        public IController gamepad{get;set;}
        public IPlayer mario { get; set; }
        public LevelStorage levelStore { get; set; }

        private ICommand keyboardNotPressed;
        private LevelLoader loader;
        private Texture2D background;
        private Rectangle mainframe;
        private TestingClass tester;
        private Camera camera;
        private CameraController cameraController;

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
            camera = new Camera(480, 800, new Vector2(0, 0));
            loader= new LevelLoader("Level.xml", camera);
            mainframe = new Rectangle(0, 0, 2000, 600);
            levelStore = new LevelStorage(camera);

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

            LoadKeyBoardCommands(); 
            levelStore=loader.LoadLevel();
            mario = levelStore.player;
            cameraController = new CameraController(camera, mario);
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
            levelStore.Update(mario,this);
            cameraController.Update();
            base.Update(gameTime);
        }

       

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(background, mainframe, Color.White);
            spriteBatch.End();

            levelStore.Draw(mario, spriteBatch);
            base.Draw(gameTime);

        }
    }
}
