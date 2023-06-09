using System.Collections.Generic;
using System.Linq;
using HumansVsAliens.Gameplay;

namespace HumansVsAliens.Tools
{
    public static class EnemiesWorldExtensions
    {
        public static List<IEnemy> DiedEnemies(this IReadOnlyEnemiesWorld enemiesWorld)
        {
            return enemiesWorld.Enemies.Where(enemy => enemy.Health.IsDied()).ToList();
        }

        public static void KillAllEnemies(this IReadOnlyEnemiesWorld enemiesWorld)
        {
            foreach (IEnemy enemy in enemiesWorld.Enemies)
            {
                if(enemy.Health.IsAlive)
                    enemy.Health.Kill();
            }
        }
    }
}