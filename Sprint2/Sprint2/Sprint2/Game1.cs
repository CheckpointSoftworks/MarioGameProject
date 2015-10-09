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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Lists to hold the gameObjects
        private ArrayList blockObjectList;
        private ArrayList itemObjectList;
        private ArrayList enemyLists;
        private IGameObject pipe;
        //Dynamic Objects based of Sprint's Description
        public IGameObject hiddenBlock;
        public IGameObject questionBlock;
        public IGameObject brickBlock;
        public IKeyboard keyboard;
        public Mario mario;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

         protected override void Initialize()
        {
            keyboard = new KeyboardController();

            blockObjectList = new ArrayList();            

            //Create all of the items.
            itemObjectList = new ArrayList();           

            //Create all of the enemies
            enemyLists = new ArrayList();

            //Mario Commands
            //Example keyboard.RegisterCommand(Keys.I, new FireMarioCommand(this));
            //Mario Movement Key Registration
            keyboard.RegisterCommand(Keys.W, new UpCommand(this));
            keyboard.RegisterCommand(Keys.Up, new UpCommand(this));
            keyboard.RegisterCommand(Keys.S, new DownCommand(this));
            keyboard.RegisterCommand(Keys.Down, new DownCommand(this));
            keyboard.RegisterCommand(Keys.A, new LeftCommand(this));
            keyboard.RegisterCommand(Keys.Left, new LeftCommand(this));
            keyboard.RegisterCommand(Keys.D, new RightCommand(this));
            keyboard.RegisterCommand(Keys.Right, new RightCommand(this));

            //Mario State Key Registration
            keyboard.RegisterCommand(Keys.Y, new SmallMarioCommand(this));
            keyboard.RegisterCommand(Keys.U, new BigMarioCommand(this));
            keyboard.RegisterCommand(Keys.I, new FireMarioCommand(this));

            //Block Commands Registration
            keyboard.RegisterCommand(Keys.Z, new QuestionBlockUsedCommand(this));
            keyboard.RegisterCommand(Keys.X, new BrickBlockDisappearCommand(this));
            keyboard.RegisterCommand(Keys.C, new HiddenBlockUsedCommand(this));

            //Misc Commands
            keyboard.RegisterCommand(Keys.R, new ResetCommand(this));

           
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // TODO: use this.Content to load your game content here
            BlockSpriteTextureStorage.Load(this.Content, GraphicsDevice);
            ItemSpriteTextureStorage.Load(this.Content, GraphicsDevice);
            EnemySpriteFactory.Load(this.Content, GraphicsDevice);
            MiscGameObjectTextureStorage.Load(this.Content, GraphicsDevice);
            MarioSpriteFactory.Load(this.Content, GraphicsDevice);

           
        }

        protected override void UnloadContent()
        {
            // Not Yet Needed in the scope of the project
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            keyboard.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            foreach (IGameObject block in blockObjectList)
            {
                block.Draw(spriteBatch);
            }

            foreach (IGameObject item in itemObjectList)
            {
                //Draw all of the items
                item.Draw(spriteBatch);
            }

            foreach (IGameObject enemy in enemyLists)
            {
                enemy.Draw(spriteBatch);
            }

            pipe.Draw(spriteBatch);

            mario.Draw(spriteBatch);

            base.Draw(gameTime);
            
        }
    }
}
