﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public static class UtilityClass
    {
        //General Magic Numbers
        public static int zero = 0;
        public static int one = 1;
        public static int two = 2;
        public static int three = 3;
        public static int four = 4;
        public static int five = 5;
        public static int eight = 8;
        public static int ten = 10;
        public static int twelve = 12;
        public static int sixteen = 16;
        public static int OneHundred = 100;

        public static float pointFive = .5f;
        public static float onePointFive = 1.5f;
        public static int nineTwentyEight = 928;
        public static int nineSixty = 960;
        public static int fourTwentyFour = 424;
        public static int threeHundred = 300;
        public static int fourHundred = 400;
        public static int fourOEight = 408;
        public static int nineThrityEight = 938;
        public static int threeSixty = 360;
        public static int threeSeventy = 370;
        public static int threeEighty = 380;
        public static int threeNintey = 390;
        public static int fourOThirtyTwo = 4032;
        public static int fourtyTwoHundred = 4200;
        public static int fourtyTwoHundredAndTen = 4210;
        public static int fourtyTwoHundredAndTwenty = 4220;
        public static int fourtyTwoHundredAndThirty = 4230;
        public static int fiftenSixteen = 1516;
        public static int twentySixHundrenAndSixtyFour = 2664;
        public static int fourtyOneHundredAndEightyEight = 4188;



        //Block Magic Numbers
        public static int BrickPieceYAdjustment = 5;
        public static int itemOffSet = 16;
        public static int BrickPieceXAdjustmentSmall = 1;
        public static int BrickPieceXAdjustmentBig = 3;
        public static int CoinDispenserLimit = 15;
        public static int BlockBounceTimer = 20;

        //Camera Magic Numbers
        public static int currentScreenMax=800;
        public static int maxScroll = 3500;

        //Collision Magic Numbers

        //Controller Magic Numbers
        public static float restoreElasticity = 0.0f;
        public static float restoreAirFriction = 0.95f;
        public static float restoreGroundFriction = 0.7f;
        public static float restoreMaxelocityX = 12.0f;
        public static float restoreMaxVelocityY = 6.0f;
        public static float restoreGroundSpeed = 6.0f;
        public static float restoreJumpSpeed = -48.0f;
        public static float restoreJumpDuration = 1.6f;
        public static float sprintMaxVelocityX = 22.8f;
        public static float sprintMaxVelocityY = 11.4f;
        public static float sprintGrounndSpeed = 11.4f;
        public static float sprintJumpSpeed = -48.0f;
        public static float sprintJumpDuration = 1.65f;
        public static int fireballSpawnXOffset = 3;
        public static int fireballSpawnYOffset = 8;
        public static float deadZone = 0.5f;

        //Enemy Magic Numbers
        public static float goombaAirFriction = 0.8f;
        public static float goombaGroundFriction = 1f;
        public static float goombaGroundSpeed =1.5f;
        public static float goombaMaxFallSpeed = 3f;
        public static float goombaElasticity = 0f;
        public static float koopaAirFriction = 1f;
        public static float koopaGroundFriction = 1f;
        public static float koopaGroundSpeed = -1f;
        public static float koopaMaxFallSpeed = 3f;
        public static float koopaElasticity = 0f;
        public static float noMovement = 0.0f;
        public static float koopShellLeftMovement = 1.0f;

        //Enviromental Magic Numbers
        public static int brickPiecesRiseAndFall = 70;
        public static int brickPiecesRise = 60;
        public static int flagpoleLocation = 3208;
        public static int aboveGroundEndLocation = 4000;

        //Item Magic Numbers
        public static int CoinTimer = 30;        
        public static float coinMoveSpeed = -4.25f;
        public static float coindecayRate = 0.32f;
        public static float fireFlowerRiseSpeed = 0.4f;
        public static float mushroomAirFriction = 0.8f;
        public static float mushroomGroundFriction = 1f;
        public static float mushroomGroundSpeed = 1.5f;
        public static float mushroomMaxFallSpeed = 3f;
        public static float mushroomElasticity = 0f;        
        public static float starAirFriction = 0.8f;
        public static float starGroundFriction = 1f;
        public static float starGroundSpeed = 1f;
        public static float starInitialAirSpeed = 0f;
        public static float starMaxFallSpeed = 3f;
        public static float starElasticity = 1f;
        public static int coinScore = 200;
        public static int itemScore = 1000;

        //Level Magic Numbers and strings
        public static int enableEnemyPixelWidth = 10;
        public static int fireballLimit = 5;
        public static int stateTransistionTimer = 20;

        //Mario Magic Numbers
        public static int marioStarTimer = 600;
        public static float marioTransitionDuration = 3f;
        public static float marioTransitionToBigTime = 10;
        public static float marioTransitionToFireTime = 10;
        public static float marioTransitionToSmallTime = 10;
        public static float marioElasticity = 0.0f;
        public static float marioAirFriction = 0.95f;
        public static float marioGroundFriction = 0.7f;
        public static float mariomaxVelocityX = 12.0f;
        public static float mariomaxVelocityY = 6.0f;
        public static float marioGroundSpeed = 6.0f;
        public static float marioJumpSpeed = -48.0f;
        public static float marioJumpDuration = 1.6f;
        public static float marioTransistionTimerCount = 0.1f;
        public static float marioTransitionDirection = 0.4f;
        public static int marioTransistionOffset = 16;

        //Mario Ending Sequence magic numbers
        public static float slideSpeed = 2.0f;
        public static float smallMarioBottomFlagLocY = 424;
        public static float bigMarioBottomFlagLocY = 408;
        public static float flipMarioBottomFlagLocX = 3224;
        public static float endMarioWalkSpeed = 0.95f;
        public static float endMarioDecayRate = 0.90f;
        public static float smallMarioGroundLocY = 440;
        public static float bigMarioGroundLocY = 424;
        public static float castleDoorWayLocX = 3308;
        public static int waitToLeaveFlagpole = 20;

        //Physics Magic Numbers
        public static float gravY=5f;
        public static float deltaTime = 0.1f;
        public static float pointFour = 0.4f;
        public static int airTime = 100;
        public static float pointOne = 0.1f;

        //Projectile Magic Numbers
        public static int fireballTimer = 200;
        public static float fireballAirFriction = 0.8f;
        public static float fireballGroundFriction = 1f;
        public static float fireballMaxFallSpeed = 1.5f;
        public static float fireballElasticity = 1f;
        public static float fireballRightGroundSpeed=1.5f;
        public static float fireballLeftGroupSpeed = -1.5f;

        //Sprite Factories and Texture Storage Magic Numbers and Strings
        
        public static string hiddenBlockSpriteSheet="HiddenBlockSpriteSheet";
        public static string brickBlockSpriteSheet="BrickBlockSpriteSheet";
        public static string questionBlockSpriteSheet="QuestionBlockSpriteSheet";
        public static string groundBlockSpriteSheet="GroundBlockSpriteSheet";
        public static string platformingBlockSpriteSheet="PlatformingBlockSpriteSheet";
        public static string brickBlockCoinDispenserSpriteSheet="BrickBlockCoinDispenser";
		public static string goombaSpriteSheet="GoombaSpriteSheet";
        public static string goombaDamagedSpriteSheet="GoombaDamagedSprite";
        public static string koopaSpriteSheet="KoopaSpriteSheet"; 
        public static string koopaShellSpriteSheet="KoopaShellSprite";
        public static string oneUpSpriteSheet="OneUpMushroom";
        public static string supMushroomSpriteSheet="SuperMushroom";
        public static string fireFlowerSpriteSheet="FireFlower";
        public static string starSpriteSheet="SuperStar";
        public static string boxCoinSpriteSheet="BoxCoin";
        public static string staticCoinSpriteSheet = "StaticCoin";
        public static string usedItemSpriteSheet="UsedItemSprite";
        public static string pipeSpriteSheet="PipeSprite";
        public static string brickPiecesSpriteSheet="BrickPieces";
        public static string fireballSpriteSheet="FireballSprite";
        public static string marioSmallStillSpriteSheet = "MarioSmallStill";
        public static string marioSmallRunningSpriteSheet = "MarioSmallRunning";
        public static string marioSmallJumpingSpriteSheet = "MarioSmallJump";
        public static string marioSmallChangeDirectionSpriteSheet = "MarioSmallChangeDirection";
        public static string marioBigStillSpriteSheet = "MarioBigStill";
        public static string marioBigRunningSpriteSheet = "MarioBigRunning";
        public static string marioBigJumpingSpriteSheet = "MarioBigJump";
        public static string marioBigChangeDirectionSpriteSheet = "MarioBigChangeDirection";
        public static string marioFireStillSpriteSheet = "MarioFireStill";
        public static string marioFireStillShootSpriteSheet = "MarioFireShootingStill";
        public static string marioFireRunningSpriteSheet = "MarioFireRunning";
        public static string marioFireRunningShootSpriteSheet = "MarioFireShootingRunning";
        public static string marioFireJumpingSpriteSheet = "MarioFireJump";
        public static string marioFireDuckSpriteSheet = "MarioFireDuck";
        public static string marioFireChangeDirectionSpriteSheet = "MarioFireChangeDirection";
        public static string marioDuckSpriteSheet = "MarioDuck";
        public static string marioDyingSpriteSheet = "MarioDying";
        public static string rightFacingPipeSpritesheet = "RightFacingPipeSprite";
        public static string rightFacingEdgePipeSpritesheet = "RightFacingPipeTallEdge";
        public static string blueBrickBlockSpriteSheet = "BlueBrickBlockSpriteSheet";
        public static string blueGroundBlockSpriteSheet ="BlueGroundBlockSpriteSheet";
        public static string marioBigFlagpoleSpriteSheet = "MarioBigFlagpole";
        public static string marioSmallFlagpoleSpriteSheet = "MarioSmallFlagpole";
        public static string marioFireFlagpoleSpriteSheet = "MarioFireFlagpole";

        //Game Magic Stuff
        public static string Content = "Content";
        public static string levelFile = "Level.xml";
        public static int cameraHeight = 480;
        public static int cameraWidth = 800;
        public static string background = "Background";
        public static string background2 = "Background2";
        public static string deathbackground = "Deathbackground";
        public static int backgroundChange = 1500;
        public static int deathbackgroundChange = 4000;
        public static int LevelStartTime = 500;
        public static string GameTimeName = "TIME\n";
        public static string gameOver = "GAME OVER";
        public static string worldLevel = "WORLD 1-1";
        public static string x = "x";
        public static int[] ChainBonusMultiplier = { 1, 2, 4, 8, 10, 20, 40, 80 };
        public static int MaximumChainBonusMultiplier = ChainBonusMultiplier.Length;
        public static int deathTimer = 5;
        public static double timeAdjustment = 2.5d;
        public static int timeLocation = 740;
        public static int deathBackgroundX = 800;
        public static int deathBackgroundY = 600;
        public static int deathMarioLocationX=365;
        public static int deathMarioLocationY=230;

        //GUI stuff
        public static float DefaultSpriteWidth = 16;
        public static int StartingLives = 3;
        public static Vector2 deathtextloc = new Vector2(350, 200);
        public static Vector2 deathmarioloc = new Vector2(387, 230);
        public static Vector2 remaininglivesloc = new Vector2(405, 230);
        public static Vector2 GUIMarioPosition = new Vector2(400, 240);
        public static Vector2 GUIMarioScorePosition = new Vector2(5,1);
        public static Vector2 GUIMarioCoinsPosition = new Vector2(100, 0);
        public static Vector2 GUILevelPosition = new Vector2(500, 0);
        public static string GUIMarioScoreName = "MARIO\n";
        public static string GUIMarioCoinName = "x";
        public static string FontString = "Fonts/SMB";
        public static string BasicArialFontString = "Fonts/BasicArial";
        public static string score = "Score:";
        public static string emptyString = "";

        //Scores
        public static int CoinScoreValue = 200;


        public static string mainTheme = "Music/maintheme";
        public static string underworldTheme = "Music/underworld";
        public static string starManTheme = "Music/starman";
        public static string deadTheme = "Music/dead";
        public static string gameOverTheme = "Music/gameover";

        
        public static string coinEffect = "Sound Effects/coin";
        public static string itemEffect = "Sound Effects/item";
        public static string oneUpEffect = "Sound Effects/1up";
        public static string jumpSmallEffect = "Sound Effects/jumpsmall";
        public static string jumpBigEffect = "Sound Effects/jumpbig";
        public static string stompEffect = "Sound Effects/stomp";
        public static string powerUpEffect = "Sound Effects/powerup";
        public static string transitionSmallEffect = "Sound Effects/pipe";
        public static string fireballEffect = "Sound Effects/fireball";
        public static string kickEffect = "Sound Effects/kick";
        public static string brickbreakEffect = "Sound Effects/breakblock";
        public static string bumpEffect = "Sound Effects/bump";
        public static string pipeEffect = "Sound Effects/pipe";
        public static string pauseEffect = "Sound Effects/pause";
    }
}
