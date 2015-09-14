//Jonathan's test commit
//Scott's test commit
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

namespace Sprint0
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        ArrayList controllerList;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public ISprite marioSprite;

        public Game1()
        {
            //Kris Added this comment and commited it
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            controllerList = new ArrayList();
            controllerList.Add(new KeyboardController(this));
            controllerList.Add(new GamepadController(this));

            marioSprite = new RunningInPlaceMario(this.Content);

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            foreach (IController controller in controllerList)
            {
                controller.Update();
            }

            marioSprite.Update();
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            marioSprite.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
