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
        private CollectableStat CoinStats { get;  set; }
        private CollectableStat SuperMushroomStats { get;  set; }
        private CollectableStat FireFlowerStats { get;  set; }
        private CollectableStat SuperStarStats { get;  set; }
        private CollectableStat KoopaStats { get;  set; }
        private CollectableStat GoombaStats { get;  set; }
        private CollectableStat BrickBlockStats { get;  set; }

        public PlayerStatManager()
        {
            CoinStats = new CollectableStat(UtilityClass.CoinName);
            SuperMushroomStats = new CollectableStat(UtilityClass.SuperMushroomName);
            FireFlowerStats = new CollectableStat(UtilityClass.FireFlowerName);
            SuperStarStats = new CollectableStat(UtilityClass.SuperStarName);
            KoopaStats = new CollectableStat(UtilityClass.KoopaName);
            GoombaStats = new CollectableStat(UtilityClass.GoombaName);
            BrickBlockStats = new CollectableStat(UtilityClass.BrickBlockName);
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
              KoopaStats = value[0];
              GoombaStats = value[1];
          }
         }
        public CollectableStat[] collectibles
        {
            get { return new CollectableStat[] { CoinStats, SuperMushroomStats, FireFlowerStats, SuperMushroomStats }; }
            private set
            {
                CoinStats = value[0];
                SuperMushroomStats = value[1];
                FireFlowerStats = value[2];
                SuperStarStats = value[3];
            }
        }

        //Temporary, please delete
        public void PrintAll()
        {
            Console.WriteLine("**************");
            foreach (CollectableStat s in collectibles)
            {   
                Console.WriteLine(s.StatName + ": " + s.StatValue);
            }
            foreach (CollectableStat s in enemyStats)
            {
                Console.WriteLine(s.StatName + ": " + s.StatValue);
            }
        }
    }
}
