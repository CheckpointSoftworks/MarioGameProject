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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public IController keyboard;
        public ICommand keyboardNotPressed;
        public IPlayer mario;
        private LevelLoader loader;
        private Texture2D background;
        private Rectangle mainframe;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            keyboard = new KeyboardController();
            keyboardNotPressed = new KeyNotPressed(this);
            loader= new LevelLoader("Level.xml");
            mainframe = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            base.Initialize();
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


            ((KeyboardController)keyboard).RegisterCommand(Keys.Y, new SmallMarioCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.U, new BigMarioCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.I, new FireMarioCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.O, new DeadMarioCommand(this));


            ((KeyboardController)keyboard).RegisterCommand(Keys.Z, new QuestionBlockUsedCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.X, new BrickBlockDisappearCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.C, new HiddenBlockUsedCommand(this));


            ((KeyboardController)keyboard).RegisterCommand(Keys.R, new ResetCommand(this));
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
            keyboardNotPressed.Execute();
            mario.Update();
            base.Update(gameTime);
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
