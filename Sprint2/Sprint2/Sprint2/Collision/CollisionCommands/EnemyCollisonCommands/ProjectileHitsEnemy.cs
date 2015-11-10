using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint2
{
    public class ProjectileHitsEnemyCollision : ICommand
    {
        private IEnemyObject enemy;
        private IProjectile projectile;
        public ProjectileHitsEnemyCollision(IEnemyObject hitEnemy, IProjectile proj)
        {
            enemy = hitEnemy;
            projectile = proj;
        }

        public void Execute()
        {
            ((Mario)((Fireball)projectile).GetOwner()).ProjectileScoreEvent(enemy.ScoreData());
            enemy.TakeDamage();
            Console.WriteLine("Fireball kill: " + ((Mario)((Fireball)projectile).GetOwner()).PointsToString());
            ((Fireball)projectile).Kill();
        }
    }
}
