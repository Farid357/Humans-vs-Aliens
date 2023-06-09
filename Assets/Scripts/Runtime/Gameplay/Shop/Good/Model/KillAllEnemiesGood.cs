using System;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class KillAllEnemiesGood : IGood
    {
        private readonly IReadOnlyEnemiesWorld _enemiesWorld;

        public KillAllEnemiesGood(IReadOnlyEnemiesWorld enemiesWorld)
        {
            _enemiesWorld = enemiesWorld ?? throw new ArgumentNullException(nameof(enemiesWorld));
        }

        public void Use()
        {
            _enemiesWorld.KillAllEnemies();
        }
    }
}