using System;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class KillAllEnemiesGood : IGood
    {
        private readonly IReadOnlyEnemiesWorld _enemiesWorld;
        private readonly IGood _good;

        public KillAllEnemiesGood(IReadOnlyEnemiesWorld enemiesWorld, IGood good)
        {
            _enemiesWorld = enemiesWorld ?? throw new ArgumentNullException(nameof(enemiesWorld));
            _good = good ?? throw new ArgumentNullException(nameof(good));
        }

        public bool IsBought => _good.IsBought;
     
        public IGoodData Data => _good.Data;

        public void Buy()
        {
            KillEnemies();
            _good.Buy();
        }

        private void KillEnemies()
        {
            foreach (IEnemy enemy in _enemiesWorld.Enemies.Keys)
            {
                if (enemy.Health.IsAlive)
                    enemy.Health.Kill();
            }
        }
    }
}