﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class MarioHitsEnemyCollision:ICommand
    {
        private IEnemyObject enemy;
        private IPlayer mario;
        public MarioHitsEnemyCollision(IEnemyObject hitEnemy, IPlayer mario){
            enemy = hitEnemy;
            this.mario = mario;
        }

        public void Execute(){
            ((Mario)mario).ScoreEvent(enemy.ScoreData());
            enemy.TakeDamage();
            ((Mario)mario).BounceOff();
        }
    }
}
