using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public static class UtilityClass
    {
        public const int zero = 0;
        public const int one = 1;
        public const int two = 2;
        public const int ten = 10;

        public const int specializedSpriteTotalFramesAndMarioRunningCols = 3;
        public const int generalTotalFramesAndSpecializedRows = 4;
        public const int marioTranstitionTimeModulus= 5;
        public const int enemyTotalFramesAndMarioFlagpoleTotalFrames = 8;
        public const int gameOverScreenWidth= 12;
        public const int generalSpriteHeightAndWidth = 16;
        public const int addCoinScore = 100;

        public const float pipeTransistionAnimationFourthFrameTime = .5f;
        public const float pipeTransistionAnimationSecondFramTime = 1.5f;
        public const int undergroundpipeleftX = 928;
        public const int undergroudpiperightX = 960;
        public const int sendAbovegroundYLocation = 424;
        public const int pipeSendBelowMarioY = 300;
        public const int pipeSendAboveGroundFinishedMarioLocationY = 400;
        public const int pipeBelowGroundTransistionX = 938;
        public const int pipeSendBelowGroundTransistionOneY = 360;
        public const int pipeSendBelowGroundTransistionTwoY = 370;
        public const int pipeSendBelowGroundTransistionThreeY = 380;
        public const int pipeSendBelowGroundTransistionFourY = 390;
        public const int pipeSendBelowMarioX = 4032;
        public const int pipeSendAboveGroundTransistionOneX = 4200;
        public const int pipeSendAboveGroundTransistionTwoX = 4210;
        public const int pipeSendAboveGroundTransistionThreeX = 4220;
        public const int pipeSendAboveGroundTransistionFourX = 4230;
        public const int pipeSendAboveCameraAdjustment = 1516;
        public const int pipeSendAboveGroundFinishedMarioLocationX = 2664;
        public const int leftfacingundergroundpipeX = 4188;
        public const int leftfacingundergroundpipeY = 408;

        public const int BrickPieceYAdjustment = 5;
        public const int itemOffSet = 16;
        public const int BrickPieceXAdjustmentSmall = 1;
        public const int BrickPieceXAdjustmentBig = 3;
        public const int CoinDispenserLimit = 15;
        public const int BlockBounceTimer = 20;

        public const int currentScreenMax = 800;
        public const int maxScroll = 3500;

        public const float restoreElasticity = 0.0f;
        public const float restoreAirFriction = 0.95f;
        public const float restoreGroundFriction = 0.7f;
        public const float restoreMaxelocityX = 12.0f;
        public const float restoreMaxVelocityY = 6.0f;
        public const float restoreGroundSpeed = 6.0f;
        public const float restoreJumpSpeed = -48.0f;
        public const float restoreJumpDuration = 1.6f;
        public const float sprintMaxVelocityX = 22.8f;
        public const float sprintMaxVelocityY = 11.4f;
        public const float sprintGrounndSpeed = 11.4f;
        public const float sprintJumpSpeed = -48.0f;
        public const float sprintJumpDuration = 1.65f;
        public const int fireballSpawnXOffset = 3;
        public const int fireballSpawnYOffset = 8;
        public const float deadZone = 0.5f;

        public const float goombaAirFriction = 0.8f;
        public const float goombaGroundFriction = 1f;
        public const float goombaGroundSpeed = 1.5f;
        public const float goombaMaxFallSpeed = 3f;
        public const float goombaElasticity = 0f;
        public const float koopaAirFriction = 1f;
        public const float koopaGroundFriction = 1f;
        public const float koopaGroundSpeed = -1f;
        public const float koopaMaxFallSpeed = 3f;
        public const float koopaElasticity = 0f;
        public const float noMovement = 0.0f;
        public const float koopShellLeftMovement = 1.0f;

        public const int brickPiecesRiseAndFall = 70;
        public const int brickPiecesRise = 60;
        public const int flagpoleLocation = 3208;
        public const int aboveGroundEndLocation = 4000;

        public const int CoinTimer = 30;
        public const float coinMoveSpeed = -4.25f;
        public const float coindecayRate = 0.32f;
        public const float fireFlowerRiseSpeed = 0.4f;
        public const float mushroomAirFriction = 0.8f;
        public const float mushroomGroundFriction = 1f;
        public const float mushroomGroundSpeed = 1.5f;
        public const float mushroomMaxFallSpeed = 3f;
        public const float mushroomElasticity = 0f;
        public const float starAirFriction = 0.8f;
        public const float starGroundFriction = 1f;
        public const float starGroundSpeed = 1f;
        public const float starInitialAirSpeed = 0f;
        public const float starMaxFallSpeed = 3f;
        public const float starElasticity = 1f;
        public const int coinScore = 200;
        public const int itemScore = 1000;

        public const int enableEnemyPixelWidth = 10;
        public const int fireballLimit = 5;
        public const int stateTransistionTimer = 20;

        //Mario Magic Numbers
        public const int marioStarTimer = 600;
        public const float marioTransitionDuration = 3f;
        public const float marioTransitionToBigTime = 10;
        public const float marioTransitionToFireTime = 10;
        public const float marioTransitionToSmallTime = 10;
        public const float marioElasticity = 0.0f;
        public const float marioAirFriction = 0.95f;
        public const float marioGroundFriction = 0.7f;
        public const float mariomaxVelocityX = 12.0f;
        public const float mariomaxVelocityY = 6.0f;
        public const float marioGroundSpeed = 6.0f;
        public const float marioJumpSpeed = -48.0f;
        public const float marioJumpDuration = 1.6f;
        public const float marioTransistionTimerCount = 0.1f;
        public const float marioMinMovementSpeed = 0.1f;
        public const float marioTransitionDirection = 0.4f;
        public const int marioTransistionOffset = 16;
        public const int marioStarColorOne = 7;
        public const int marioStarColorTwo = 5;
        public const int marioStarColorThree = 4;

        //Mario Ending Sequence Magic Numbers
        public const float slideSpeed = 2.0f;
        public const float smallMarioBottomFlagLocY = 424;
        public const float bigMarioBottomFlagLocY = 408;
        public const float flipMarioBottomFlagLocX = 3224;
        public const float endMarioWalkSpeed = 0.95f;
        public const float endMarioDecayRate = 0.90f;
        public const float smallMarioGroundLocY = 440;
        public const float bigMarioGroundLocY = 424;
        public const float castleDoorWayLocX = 3308;
        public const int waitToLeaveFlagpole = 35;

        //flagPole Magic Numbers
        public const float flagLocationX = 3208;
        public const float flagLocationY = 298;
        public const float flagAtBottomLocationY = 420;
        public const float flagMoveSpeed = 1.2f;
        public const float poleLocationX = 3216;
        public const float poleLocationY = 280;

        //Physics Magic Numbers
        public const float gravY = 5f;
        public const float deltaTime = 0.1f;
        public const float pointFour = 0.4f;
        public const int airTime = 100;
        public const float pointOne = 0.1f;

        //Projectile Magic Numbers
        public const int fireballTimer = 200;
        public const float fireballAirFriction = 0.8f;
        public const float fireballGroundFriction = 1f;
        public const float fireballMaxFallSpeed = 1.5f;
        public const float fireballElasticity = 1f;
        public const float fireballRightGroundSpeed = 1.5f;
        public const float fireballLeftGroupSpeed = -1.5f;

        //Sprite Factories and Texture Storage Magic Numbers and Strings

        public const string hiddenBlockSpriteSheet = "HiddenBlockSpriteSheet";
        public const string brickBlockSpriteSheet = "BrickBlockSpriteSheet";
        public const string questionBlockSpriteSheet = "QuestionBlockSpriteSheet";
        public const string groundBlockSpriteSheet = "GroundBlockSpriteSheet";
        public const string platformingBlockSpriteSheet = "PlatformingBlockSpriteSheet";
        public const string brickBlockCoinDispenserSpriteSheet = "BrickBlockCoinDispenser";
        public const string goombaSpriteSheet = "GoombaSpriteSheet";
        public const string goombaDamagedSpriteSheet = "GoombaDamagedSprite";
        public const string koopaSpriteSheet = "KoopaSpriteSheet";
        public const string koopaShellSpriteSheet = "KoopaShellSprite";
        public const string oneUpSpriteSheet = "OneUpMushroom";
        public const string supMushroomSpriteSheet = "SuperMushroom";
        public const string fireFlowerSpriteSheet = "FireFlower";
        public const string starSpriteSheet = "SuperStar";
        public const string boxCoinSpriteSheet = "BoxCoin";
        public const string staticCoinSpriteSheet = "StaticCoin";
        public const string usedItemSpriteSheet = "UsedItemSprite";
        public const string pipeSpriteSheet = "PipeSprite";
        public const string brickPiecesSpriteSheet = "BrickPieces";
        public const string fireballSpriteSheet = "FireballSprite";
        public const string marioSmallStillSpriteSheet = "MarioSmallStill";
        public const string marioSmallRunningSpriteSheet = "MarioSmallRunning";
        public const string marioSmallJumpingSpriteSheet = "MarioSmallJump";
        public const string marioSmallChangeDirectionSpriteSheet = "MarioSmallChangeDirection";
        public const string marioBigStillSpriteSheet = "MarioBigStill";
        public const string marioBigRunningSpriteSheet = "MarioBigRunning";
        public const string marioBigJumpingSpriteSheet = "MarioBigJump";
        public const string marioBigChangeDirectionSpriteSheet = "MarioBigChangeDirection";
        public const string marioFireStillSpriteSheet = "MarioFireStill";
        public const string marioFireStillShootSpriteSheet = "MarioFireShootingStill";
        public const string marioFireRunningSpriteSheet = "MarioFireRunning";
        public const string marioFireRunningShootSpriteSheet = "MarioFireShootingRunning";
        public const string marioFireJumpingSpriteSheet = "MarioFireJump";
        public const string marioFireDuckSpriteSheet = "MarioFireDuck";
        public const string marioFireChangeDirectionSpriteSheet = "MarioFireChangeDirection";
        public const string marioDuckSpriteSheet = "MarioDuck";
        public const string marioDyingSpriteSheet = "MarioDying";
        public const string rightFacingPipeSpritesheet = "RightFacingPipeSprite";
        public const string rightFacingEdgePipeSpritesheet = "RightFacingPipeTallEdge";
        public const string blueBrickBlockSpriteSheet = "BlueBrickBlockSpriteSheet";
        public const string blueGroundBlockSpriteSheet = "BlueGroundBlockSpriteSheet";
        public const string marioBigFlagpoleSpriteSheet = "MarioBigFlagpole";
        public const string marioSmallFlagpoleSpriteSheet = "MarioSmallFlagpole";
        public const string marioFireFlagpoleSpriteSheet = "MarioFireFlagpole";
        public const string poleSpriteSheet = "Pole";
        public const string flagSpriteSheet = "Flag";

        //Game Magic Stuff
        public const string Content = "Content";
        public const string levelFile = "Level.xml";
        public const int cameraHeight = 480;
        public const int cameraWidth = 800;
        public const string background = "Background";
        public const string background2 = "Background2";
        public const string deathbackground = "Deathbackground";
        public const int backgroundChange = 1500;
        public const int deathbackgroundChange = 4000;
        public const int LevelStartTime = 500;
        public const string GameTimeName = "TIME\n";
        public const string gameOver = "GAME OVER";
        public const string worldLevel = "WORLD 1-1";
        public const string x = "x";
        public static int[] ChainBonusMultiplier = { 1, 2, 4, 8, 10, 20, 40, 80 };
        public static int MaximumChainBonusMultiplier = ChainBonusMultiplier.Length;
        public const int deathTimer = 5;
        public const double timeAdjustment = 2.5d;
        public const int timeLocation = 740;
        public const int deathBackgroundX = 800;
        public const int deathBackgroundY = 600;
        public const int deathMarioLocationX = 365;
        public const int deathMarioLocationY = 230;

        //GUI stuff
        public const float DefaultSpriteWidth = 16;
        public const int StartingLives = 3;
        public static Vector2 deathtextloc = new Vector2(350, 200);
        public static Vector2 deathmarioloc = new Vector2(387, 230);
        public static Vector2 remaininglivesloc = new Vector2(405, 230);
        public static Vector2 GUIMarioPosition = new Vector2(400, 240);
        public static Vector2 GUIMarioScorePosition = new Vector2(5, 1);
        public static Vector2 GUIMarioCoinsPosition = new Vector2(100, 0);
        public static Vector2 GUILevelPosition = new Vector2(500, 0);
        public static Vector2 GUICollectableStatsPosition = new Vector2(10, 40);
        public static Vector2 GUIActionStatsPosition = new Vector2(10, 150);
        public static Vector2 TimeStatPosition = new Vector2(500,50);
        public const string GUIMarioScoreName = "MARIO\n";
        public const string GUIMarioCoinName = "x";
        public const string FontString = "Fonts/SMB";
        public const string BasicArialFontString = "Fonts/BasicArial";
        public const string score = "Score:";
        public const string emptyString = "";
        public const string guiMarioSprite = "MarioSmallStill";
        public const string guiCoinSprite = "BoxCoin";

        public const int CoinScoreValue = 200;


        public const string mainTheme = "Music/maintheme";
        public const string underworldTheme = "Music/underworld";
        public const string starManTheme = "Music/starman";
        public const string deadTheme = "Music/dead";
        public const string gameOverTheme = "Music/gameover";


        public const string coinEffect = "Sound Effects/coin";
        public const string itemEffect = "Sound Effects/item";
        public const string oneUpEffect = "Sound Effects/1up";
        public const string jumpSmallEffect = "Sound Effects/jumpsmall";
        public const string jumpBigEffect = "Sound Effects/jumpbig";
        public const string stompEffect = "Sound Effects/stomp";
        public const string powerUpEffect = "Sound Effects/powerup";
        public const string transitionSmallEffect = "Sound Effects/pipe";
        public const string fireballEffect = "Sound Effects/fireball";
        public const string kickEffect = "Sound Effects/kick";
        public const string brickbreakEffect = "Sound Effects/breakblock";
        public const string bumpEffect = "Sound Effects/bump";
        public const string pipeEffect = "Sound Effects/pipe";
        public const string pauseEffect = "Sound Effects/pause";

        public const string CoinName = "Coin";
        public const string SuperMushroomName = "Super Mushroom";
        public const string FireFlowerName = "Fire Flower";
        public const string SuperStarName = "Super Star";
        public const string KoopaName = "Koopa";
        public const string GoombaName = "Goomba";
        public const string BrickBlockName = "Brick Blocks";

    }
}
