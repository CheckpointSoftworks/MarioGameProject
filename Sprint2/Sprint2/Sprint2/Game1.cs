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

        public ArrayList staticObjectsList;
        public ArrayList dynamicObjectsList;

        public IGameObject hiddenBlock;
        public IGameObject questionBlock;
        public IGameObject brickBlock;
        public IController keyboard;
        public Mario mario;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            keyboard = new KeyboardController();

            staticObjectsList = new ArrayList();           
            dynamicObjectsList = new ArrayList();      
           
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            

            BlockSpriteTextureStorage.Load(this.Content);
            ItemSpriteTextureStorage.Load(this.Content, GraphicsDevice);
            EnemySpriteFactory.Load(this.Content, GraphicsDevice);
            MiscGameObjectTextureStorage.Load(this.Content, GraphicsDevice);
            MarioSpriteFactory.Load(this.Content);


            mario = new Mario();

            LoadDynamicObjects(dynamicObjectsList);
            LoadStaticObjects(staticObjectsList);    
            LoadKeyBoardCommands(keyboard);
        }

        private void LoadDynamicObjects(ArrayList dynaimcObjectList)
        {
            hiddenBlock = new HiddenBlock();
            questionBlock = new QuestionBlock();
            brickBlock = new BrickBlock();

            dynaimcObjectList.Add(hiddenBlock);
            dynaimcObjectList.Add(questionBlock);
            dynaimcObjectList.Add(brickBlock);
        }

        private void LoadStaticObjects(ArrayList staticObjectsList)
        {
            staticObjectsList.Add(new FireFlower());
            staticObjectsList.Add(new BoxCoin());
            staticObjectsList.Add(new SuperMushroom());
            staticObjectsList.Add(new OneUpMushroom());
            staticObjectsList.Add(new SuperStar());
            staticObjectsList.Add(new GroundBlock());
            staticObjectsList.Add(new PlatformingBlock());
            staticObjectsList.Add(new Pipe());
            staticObjectsList.Add(new Goomba());
            staticObjectsList.Add(new Koopa());
        }

        private void LoadKeyBoardCommands(IController keyboard)
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
            mario.Update();

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.CornflowerBlue);


            foreach (IGameObject staticObject in staticObjectsList)
            {
                
                staticObject.Draw(spriteBatch);
            }

            foreach (IGameObject dynamicObject in dynamicObjectsList)
            {
                dynamicObject.Draw(spriteBatch);
            }

            mario.Draw(spriteBatch);

            base.Draw(gameTime);
            
        }
    }
}
