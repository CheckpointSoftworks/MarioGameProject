using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class EnemyHitsMarioCollision:ICommand
    {
        private Mario mario;
        private IEnemyObject enemy;

        public EnemyHitsMarioCollision(Mario mario,IEnemyObject enemy)
        {
            this.mario = mario;
            this.enemy = enemy;
        }

        public void Execute()
        {
            if (!((Mario)mario).Star)
            {
                mario.TakeDamage();
            }
            else
            {
                enemy.TakeDamage(mario);
            }
        }
    }
}
