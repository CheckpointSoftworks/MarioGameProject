using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class PlayerStatManager
    {
        private CoinStats CoinStats { get;  set; }
        private SuperMushroomStats SuperMushroomStats { get;  set; }
        private FireFlowerStats FireFlowerStats { get;  set; }
        private SuperStarStats SuperStarStats { get;  set; }
        private KoopaStats KoopaStats { get;  set; }
        private GoombaStats GoombaStats { get;  set; }
        private BreakableBlockStats BrickBlockStats { get;  set; }

        public PlayerStatManager()
        {
            CoinStats = new CoinStats(UtilityClass.CoinName);
            SuperMushroomStats = new SuperMushroomStats(UtilityClass.SuperMushroomName);
            FireFlowerStats = new FireFlowerStats(UtilityClass.FireFlowerName);
            SuperStarStats = new SuperStarStats(UtilityClass.SuperStarName);
            KoopaStats = new KoopaStats(UtilityClass.KoopaName);
            GoombaStats = new GoombaStats(UtilityClass.GoombaName);
            BrickBlockStats = new BreakableBlockStats(UtilityClass.BrickBlockName);
        }
        public void GotCoin()
        {
            CoinStats.IncreaseValue(1);
        }

        public void GotSuperMushroom()
        {
            SuperMushroomStats.IncreaseValue(1);
        }

        public void GotFireFlower()
        {
            FireFlowerStats.IncreaseValue(1);
        }

        public void GotSuperStar()
        {
            SuperStarStats.IncreaseValue(1);
        }
        public void BrokeBrickBlock()
        {
            BrickBlockStats.IncreaseValue(1);
        }

        public void KilledGoomba()
        {
            GoombaStats.IncreaseValue(1);
        }

        public void KilledKoopa()
        {
            KoopaStats.IncreaseValue(1);
        }

        public CollectableStat[] enemyStats
        {
          get { return new CollectableStat[] { KoopaStats, GoombaStats }; }
          private set
          {
             // KoopaStats = value[0];
             // GoombaStats = value[1];
          }
         }
        public CollectableStat[] collectibles
        {
            get { return new CollectableStat[] { CoinStats, SuperMushroomStats, FireFlowerStats, SuperMushroomStats }; }
            private set
            {
               // CoinStats = value[0];
               // SuperMushroomStats = value[1];
               // FireFlowerStats = value[2];
                //SuperStarStats = value[3];
            }
        }

        //Temporary, please delete
        public void PrintAll()
        {
            Console.WriteLine("********** Player Stats **********");
            Console.WriteLine("Koopas: " + KoopaStats.StatValueInt + "/" + KoopaStats.TotalAvailable);
            Console.WriteLine("Goomba: " + GoombaStats.StatValueInt + "/" + GoombaStats.TotalAvailable);
            Console.WriteLine("Coin: " + CoinStats.StatValueInt + "/" + CoinStats.TotalAvailable);
            Console.WriteLine("SuperMushroom: " + SuperMushroomStats.StatValueInt + "/" + SuperMushroomStats.TotalAvailable);
            Console.WriteLine("FireFlower: " + FireFlowerStats.StatValueInt + "/" + FireFlowerStats.TotalAvailable);
            Console.WriteLine("SuperStar: " + SuperStarStats.StatValueInt + "/" + SuperStarStats.TotalAvailable);
        }

        public void DrawTotals(SpriteBatch spriteBatch, SpriteFont font, Vector2 loc)
        {
            String totals = "Koopas  " + KoopaStats.StatValueInt +" of " + KoopaStats.TotalAvailable + "\n" +
                            "Goomba  " + GoombaStats.StatValueInt + " of " + GoombaStats.TotalAvailable + "\n" +
                            "Coins  " + CoinStats.StatValueInt +" of " + CoinStats.TotalAvailable + "\n" +
                            "SuperMushroom  " + SuperMushroomStats.StatValueInt + " of " + SuperMushroomStats.TotalAvailable + "\n" +
                            "FireFlower  " + FireFlowerStats.StatValueInt + " of " + FireFlowerStats.TotalAvailable + "\n" +
                            "SuperStar  " + SuperStarStats.StatValueInt + " of " + SuperStarStats.TotalAvailable + "\n";
            spriteBatch.DrawString(font, totals, loc, Color.White);
            
        }
    }
}
