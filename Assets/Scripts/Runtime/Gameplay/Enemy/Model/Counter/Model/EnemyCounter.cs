using System;
using System.Linq;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public sealed class EnemyCounter : IEnemyCounter
    {
        private readonly IReadOnlyEnemiesWorld _enemiesWorld;
        private readonly IEnemyCounterView _view;
       
        private int _lastShowedCount;

        public EnemyCounter(IReadOnlyEnemiesWorld enemiesWorld, IEnemyCounterView view)
        {
            _enemiesWorld = enemiesWorld ?? throw new ArgumentNullException(nameof(enemiesWorld));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public void Update(float deltaTime)
        {
            int currentEnemiesCount = _enemiesWorld.Enemies.Count(enemy => enemy.Health.IsAlive);

            if (_lastShowedCount != currentEnemiesCount)
            {
                _view.Show(currentEnemiesCount);
                _lastShowedCount = currentEnemiesCount;
            }
        }
    }
}