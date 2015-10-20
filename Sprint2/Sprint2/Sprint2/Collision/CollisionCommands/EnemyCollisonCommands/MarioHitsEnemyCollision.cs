using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class MarioHitsEnemyCollision:ICommand
    {
        private IEnemyObject enemy;
        public MarioHitsEnemyCollision(IEnemyObject hitEnemy){
            enemy = hitEnemy;
        }

        public void Execute(){
            enemy.TakeDamage();
        }
    }
}
