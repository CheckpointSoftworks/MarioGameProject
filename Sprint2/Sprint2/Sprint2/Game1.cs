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
        public PipeTransition pipeTransition { get; set; }
        public GameOver gameover { get; set; }
        public bool pause { get; set; }
        public bool canPause { get; set; }
        public bool marioPause { get; set; }
        public int fireBallCount { get; set; }
        public int stateTransistionPauseTimer { get; set; }
        private Texture2D background;
        private Texture2D background2;
        private Texture2D deathbackground;
        private TestingClass tester;
        public ICommand resetCommand;
        private ICommand keyNotPressed;
        private SpriteFont font;
        private SpriteFont basicarialfont;
        private TimeStat time;
        public GUI gui;
        public IEndingSequenceMario endMario { get; set; }
        public IPole pole { get; set; }
        public IFlag flag { get; set; }
        public bool hitFlagpole { get; set; }

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
            pipeTransition = new PipeTransition();
            gameover = new GameOver(this);
            loader = new LevelLoader(UtilityClass.levelFile, camera);
            levelStore = new LevelStorage(camera);
            keyNotPressed = new KeyNotPressed(this);
            fireBallCount = UtilityClass.fireballLimit;
            pause = false;
            canPause = true;
            marioPause = false;
            stateTransistionPauseTimer = UtilityClass.stateTransistionTimer;
            time = new TimeStat(UtilityClass.LevelStartTime);
            gui = new GUI();
            StatePuaseAlterationCall.setGame(this);
            base.Initialize();
            tester.runTests();
            pole = new Pole();
            flag = new Flag();
            hitFlagpole = false;
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
            SoundEffectFactory.Load(this.Content);
            MusicFactory.Load(this.Content);
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
            MusicFactory.MainTheme();
            ResetGui();
        }

        public void ResetGui()
        {
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
            ((KeyboardController)keyboard).RegisterCommand(Keys.Q, new QuitCommand(this));
        }
        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            if (!hitFlagpole)
            {
                keyboard.Update();
                gamepad.Update();
            }

            float elapsedtime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (!pause&&!marioPause)
            {
                keyNotPressed.Execute();
                mario.Update();
                levelStore.Update();
                levelStore.handleCollision(mario, this);
                cameraController.Update();
                pipeTransition.Update((Mario)mario, elapsedtime, camera);
                gameover.Update((Mario)mario, elapsedtime, this);
                gui.Update();
                if (time.UpdateTime(gameTime)) { resetCommand.Execute(); }
                base.Update(gameTime);
            }

            else if (marioPause&&!pause)
            {
                mario.Update();
                levelStore.handleCollision(mario, this);
                stateTransistionPauseTimer--;
            }

            if (stateTransistionPauseTimer == UtilityClass.zero) { StatePuaseAlterationCall.Execute(); }

            pole.Update();
            flag.Update();
            if (mario.returnLocation().X >= UtilityClass.flagpoleLocation && mario.returnLocation().X < UtilityClass.aboveGroundEndLocation)
            {
                if (!hitFlagpole)
                {
                    endMario = new EndingSequenceMario(mario.returnLocation(), ((Mario)mario).Small, ((Mario)mario).Fire);
                    hitFlagpole = true;
                }
                flag.MoveDown();
                endMario.FlagAtBottom = flag.FlagAtBottom();
                endMario.Update();
                if (endMario.EndSequenceFinished)
                {
                    resetCommand.Execute();
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            if (gameover.deathscreen)
            {
                gameover.Draw(this);
            }
            else
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                spriteBatch.Begin();
                Rectangle sourceRectangle = new Rectangle((int)camera.GetPosition().X, (int)camera.GetPosition().Y, UtilityClass.cameraWidth, UtilityClass.cameraHeight);
                Rectangle destinationRectangle = new Rectangle(UtilityClass.zero, UtilityClass.zero, UtilityClass.cameraWidth, UtilityClass.cameraHeight);
                if (mario.returnLocation().X > UtilityClass.deathbackgroundChange)
                {
                    spriteBatch.Draw(deathbackground, destinationRectangle, sourceRectangle, Color.White);
                }
                else if ((int)camera.GetPosition().X < UtilityClass.backgroundChange) { spriteBatch.Draw(background, destinationRectangle, sourceRectangle, Color.White); }
                else
                {
                    sourceRectangle = new Rectangle((int)camera.GetPosition().X - UtilityClass.backgroundChange, (int)camera.GetPosition().Y, UtilityClass.cameraWidth, UtilityClass.cameraHeight);
                    spriteBatch.Draw(background2, destinationRectangle, sourceRectangle, Color.White);
                }
                spriteBatch.DrawString(font, UtilityClass.GameTimeName + time.FormattedTime(), new Vector2(UtilityClass.timeLocation, UtilityClass.ten), Color.White);
                spriteBatch.DrawString(basicarialfont, UtilityClass.worldLevel, UtilityClass.GUILevelPosition, Color.White);
                gui.DrawPlayGUI(spriteBatch, font);
                levelStore.Draw(mario, spriteBatch, hitFlagpole);

                pole.Draw(spriteBatch, camera.GetPosition());
                flag.Draw(spriteBatch, camera.GetPosition());
                if (mario.returnLocation().X >= UtilityClass.flagpoleLocation && mario.returnLocation().X < UtilityClass.aboveGroundEndLocation)
                {
                    endMario.Draw(spriteBatch, camera.GetPosition());
                }
                spriteBatch.End();
                base.Draw(gameTime);
            }
        }

        public void ResetTime()
        {
            time.ResetTime();
        }
    }
}
