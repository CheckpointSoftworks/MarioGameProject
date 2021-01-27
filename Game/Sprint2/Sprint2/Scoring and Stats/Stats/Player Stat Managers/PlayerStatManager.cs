using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

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
            spriteBatch.DrawString(font, GetInformation(), loc, Color.White);
        }

        public string GetInformation()
        {
            String totals = KoopaStats.StatName + " " + KoopaStats.StatValueInt + " of " + KoopaStats.TotalAvailable + "\n" +
                            GoombaStats.StatName + " " + GoombaStats.StatValueInt + " of " + GoombaStats.TotalAvailable + "\n" +
                            CoinStats.StatName + " " + CoinStats.StatValueInt + " of " + CoinStats.TotalAvailable + "\n" +
                            SuperMushroomStats.StatName + " " + SuperMushroomStats.StatValueInt + " of " + SuperMushroomStats.TotalAvailable + "\n" +
                            FireFlowerStats.StatName + " " + FireFlowerStats.StatValueInt + " of " + FireFlowerStats.TotalAvailable + "\n" +
                            SuperStarStats.StatName + " " + SuperStarStats.StatValueInt + " of " + SuperStarStats.TotalAvailable + "\n";
            return totals;
        }

        public void WriteInformtionToFile(TextWriter sw)
        {
            sw.WriteLine(KoopaStats.StatName + "s: " + KoopaStats.StatValueInt + " of " + KoopaStats.TotalAvailable);
            sw.WriteLine(GoombaStats.StatName + "s: " + GoombaStats.StatValueInt + " of " + GoombaStats.TotalAvailable);
            sw.WriteLine(CoinStats.StatName + "s: " + CoinStats.StatValueInt + " of " + CoinStats.TotalAvailable);
            sw.WriteLine(SuperMushroomStats.StatName + "s: " + SuperMushroomStats.StatValueInt + " of " + SuperMushroomStats.TotalAvailable);
            sw.WriteLine(FireFlowerStats.StatName + "s: " + FireFlowerStats.StatValueInt + " of " + FireFlowerStats.TotalAvailable);
            sw.WriteLine(SuperStarStats.StatName + "s: " + SuperStarStats.StatValueInt + " of " + SuperStarStats.TotalAvailable);
            sw.WriteLine("*****************************");
            sw.WriteLine();
        }
    }
}
