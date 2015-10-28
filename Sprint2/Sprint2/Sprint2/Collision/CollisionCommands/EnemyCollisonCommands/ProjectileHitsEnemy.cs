using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class ProjectileHitsEnemyCollision : ICommand
    {
        private IEnemyObject enemy;
        public ProjectileHitsEnemyCollision(IEnemyObject hitEnemy)
        {
            enemy = hitEnemy;
        }

        public void Execute()
        {
            enemy.TakeDamage();

        }
    }
}
