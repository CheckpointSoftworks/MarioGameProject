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
        public GraphicsDeviceManager graphics { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public IController keyboard { get; set; }
        public IController gamepad { get; set; }
        public IPlayer mario { get; set; }
        public LevelStorage levelStore { get; set; }
        public LevelLoader loader { get; set; }
        public Camera camera { get; set; }
        public CameraController cameraController { get; set; }
        public bool pause { get; set; }
        public bool canPause { get; set; }
        public int fireBallCount { get; set; }
        private Texture2D background;
        private Texture2D background2;
        private Texture2D deathbackground;
        private float deathtime = 5;
        private int remaininglives = 3;
        private Boolean deathscreen = false;
        private TestingClass tester;
        private ICommand resetCommand;
        private ICommand keyNotPressed;
        private SpriteFont font;
        private SpriteFont basicarialfont;
        private double time;
        private GUI gui;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = UtilityClass.Content;
        }

        protected override void Initialize()
        {
            tester = new TestingClass(this);
            keyboard = new KeyboardController();
            gamepad = new GamepadController(this);
            camera = new Camera(UtilityClass.cameraHeight, UtilityClass.cameraWidth, new Vector2(UtilityClass.zero, UtilityClass.zero));
            loader = new LevelLoader(UtilityClass.levelFile, camera);
            levelStore = new LevelStorage(camera);
            keyNotPressed = new KeyNotPressed(this);
            fireBallCount = UtilityClass.fireballLimit;
            pause = false;
            canPause = true;
            time = UtilityClass.LevelStartTime;
            gui = new GUI();
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
            GUISpriteFactory.Load(this.Content);
            background = Content.Load<Texture2D>(UtilityClass.background);
            background2 = Content.Load<Texture2D>(UtilityClass.background2);
            deathbackground = Content.Load<Texture2D>(UtilityClass.deathbackground);
            font = Content.Load<SpriteFont>(UtilityClass.FontString);
            basicarialfont = Content.Load<SpriteFont>(UtilityClass.BasicArialFontString);
            LoadKeyBoardCommands();
            levelStore = loader.LoadLevel();
            mario = levelStore.player;
            cameraController = new CameraController(camera, mario);
            resetCommand = new ResetLevelCommand(this);
            gui.Subscribe(((Mario)mario).GetPoints());
            gui.Subscribe(((Mario)mario).GetLives());
            gui.Subscribe(((Mario)mario).GetCoins());
        }

        private void LoadKeyBoardCommands()
        {
            ((KeyboardController)keyboard).RegisterCommand(Keys.Z, new UpCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.Down, new DownCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.Left, new LeftCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.Right, new RightCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.X, new FireballCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.R, new ResetLevelCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.S, new SprintCommand(this));
            ((KeyboardController)keyboard).RegisterCommand(Keys.P, new PauseCommand(this));
            ((KeyboardController)keyboard).RegisterReleasedCommand(Keys.Z,new NoJumpCommand(this));
            ((KeyboardController)keyboard).RegisterReleasedCommand(Keys.X, new NoFireCommand(this));
            ((KeyboardController)keyboard).RegisterReleasedCommand(Keys.P,new NoPauseCommand(this));
        }
        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            keyboard.Update();
            if (!pause)
            {
                gamepad.Update();
                keyNotPressed.Execute();
                mario.Update();
                levelStore.Update(mario);
                levelStore.handleCollision(mario, this);
                cameraController.Update();
                if (((Mario)mario).StateStatus().Equals(MarioState.Die))
                {
                    if (deathtime > 0)
                    {
                        deathscreen = true;
                        deathtime = deathtime - (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    else
                    {
                        deathscreen = false;
                        resetCommand.Execute();
                        ResetTime();
                        deathtime = 5;
                    }
                }
                if (((int)(((Mario)mario).Location.Y)) > camera.GetHeight())
                {
                    if (deathtime > 0)
                    {
                        deathscreen = true;
                        deathtime = deathtime - (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    else
                    {
                        deathscreen = false;
                        resetCommand.Execute();
                        ResetTime();
                        deathtime = 5;
                    }
                }
                gui.Update();
                UpdateTime(gameTime);
                base.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            if (deathscreen)
            {
                Rectangle sourceRectangle = new Rectangle((int)camera.GetPosition().X, (int)camera.GetPosition().Y, 800, 480);
                Rectangle destinationRectangle = new Rectangle(0, 0, 800, 480);
                spriteBatch.Begin();
                spriteBatch.Draw(deathbackground, destinationRectangle, sourceRectangle, Color.Black);
                if (remaininglives > 0)
                {
                    spriteBatch.DrawString(basicarialfont, "WORLD 1-1",
                            UtilityClass.deathtextloc, Color.White);
                    gui.DrawPlayGUI(spriteBatch, font);
                }
                else
                {
                    spriteBatch.DrawString(basicarialfont, "GAME OVER",
                            UtilityClass.deathtextloc, Color.White);

                    gui.DrawPlayGUI(spriteBatch, font);
                }
                spriteBatch.End();
            }
            else
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                spriteBatch.Begin();
                Rectangle sourceRectangle = new Rectangle((int)camera.GetPosition().X, (int)camera.GetPosition().Y, UtilityClass.cameraWidth, UtilityClass.cameraHeight);
                Rectangle destinationRectangle = new Rectangle(UtilityClass.zero, UtilityClass.zero, UtilityClass.cameraWidth, UtilityClass.cameraHeight);
                if ((int)camera.GetPosition().X < 1500) { spriteBatch.Draw(background, destinationRectangle, sourceRectangle, Color.White); }
                else
                {
                    sourceRectangle = new Rectangle((int)camera.GetPosition().X - UtilityClass.backgroundChange, (int)camera.GetPosition().Y, UtilityClass.cameraWidth, UtilityClass.cameraHeight);
                    spriteBatch.Draw(background2, destinationRectangle, sourceRectangle, Color.White);
                }
                spriteBatch.DrawString(font, UtilityClass.GameTimeName + FormattedTime(), new Vector2(740, 10), Color.White);
                gui.DrawPlayGUI(spriteBatch, font);
                levelStore.Draw(mario, spriteBatch);
                spriteBatch.End();
                base.Draw(gameTime);
            }
        }

        protected void UpdateTime(GameTime gameTime)
        {
            time -= gameTime.ElapsedGameTime.TotalSeconds * 2.5d;
            if (time <= 0)
            {
                resetCommand.Execute();
                ResetTime();
            }
        }

        private void ResetTime()
        {
            time = UtilityClass.LevelStartTime;
        }

        private String FormattedTime()
        {
            return Math.Round(time, UtilityClass.zero).ToString();
        }
    }
}
