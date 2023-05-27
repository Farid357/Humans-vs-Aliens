using System.Collections.Generic;
using System.Linq;
using HumansVsAliens.Gameplay;

namespace HumansVsAliens.Tools
{
    public static class EnemiesWorldExtensions
    {
        public static List<IEnemy> DiedEnemies(this IReadOnlyEnemiesWorld enemiesWorld)
        {
            return enemiesWorld.Enemies.Keys.Where(enemy => enemy.Health.IsDied()).ToList();
        }
    }
}