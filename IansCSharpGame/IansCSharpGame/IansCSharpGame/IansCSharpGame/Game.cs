using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

//Student: Ian Weber (weber.595, 3:00 Section)
//Last Update: September 5, 2015.
//Sprint0
//No further comments are included as requested in class.
namespace IansCSharpGame
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        //Matt Edited and committed this line
        //Kris Added this comment and commtied it
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont mainfont;
        private string Goodbye = "You have selected to quit the game.  Goodbye!";
        private string Hello = "Hello and welcome to IansCSharpGame! Please press q, w, e, or r.";
        private int ExampleGameTime = 0; 
        private NonmovingSprite NonMovingAnimatedSprite; 
        private MovingNonAnimSprite UpAndDownSprite; 
        private MovingAnimSprite WalkingSprite; 
        IController mycontroller = new KeyboardController();
        ISprite mysprite; 
        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mainfont = Content.Load<SpriteFont>("HelloGoodbye");
            Texture2D texture = Content.Load<Texture2D>("MarioWalkTransparent");
            NonMovingAnimatedSprite = new NonmovingSprite(texture, 4, 4);
            UpAndDownSprite = new MovingNonAnimSprite(texture, 4, 4);
            WalkingSprite = new MovingAnimSprite(texture, 4, 4);
        }
        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            mycontroller.Update(); 

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || mycontroller.QWasPressed==true)
                this.Exit();

            if(mycontroller.WWasPressed)
            {
                mysprite = NonMovingAnimatedSprite; 
                mysprite.Update(); 
            }
            if(mycontroller.EWasPressed)
            {
                mysprite = UpAndDownSprite;
                mysprite.Update();
            }
            if(mycontroller.RWasPressed)
            {
                mysprite = WalkingSprite;
                mysprite.Update();
            }
           
            ExampleGameTime++;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.DrawString(mainfont, Hello, new Vector2(50, 50), Color.Black);
            spriteBatch.DrawString(mainfont, "Game time: " + ExampleGameTime, new Vector2(50, 120), Color.Black);
            spriteBatch.End();

            if (mycontroller.WWasPressed)
            {
                mysprite.Draw(spriteBatch, new Vector2(400, 200));
            }
            if (mycontroller.EWasPressed)
            {
                mysprite.Draw(spriteBatch, new Vector2(400, 200));
            }
            if (mycontroller.RWasPressed)
            {
                mysprite.Draw(spriteBatch, new Vector2(400, 200));
            }
            
            base.Draw(gameTime);
        }
    }
}
