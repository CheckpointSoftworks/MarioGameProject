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
            SoundEffectFactory.Kick();
            if (projectile.ReturnProjectileType().Equals(ProjectileType.Fireball))
            {
                ((Mario)((Fireball)projectile).GetOwner()).ProjectileScoreEvent(enemy.ScoreData());
                enemy.TakeDamage(((Mario)((Fireball)projectile).GetOwner()));
                ((Fireball)projectile).Killed();
            }
            else if (projectile.ReturnProjectileType().Equals(ProjectileType.Iceball))
            {
                ((Mario)((Iceball)projectile).GetOwner()).ProjectileScoreEvent(enemy.ScoreData());
                enemy.Freeze();
                ((Iceball)projectile).Killed();
            }
        }
    }
}
