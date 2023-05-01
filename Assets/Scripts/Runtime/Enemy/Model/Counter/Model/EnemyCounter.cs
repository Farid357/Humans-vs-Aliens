using System;
using HumansVsAliens.GameLoop;
using HumansVsAliens.View;

namespace HumansVsAliens.Model
{
    public class EnemyCounter : IGameLoopObject
    {
        private readonly IReadOnlyEnemiesWorld _enemiesWorld;
        private readonly IEnemyCounterView _view;

        public EnemyCounter(IReadOnlyEnemiesWorld enemiesWorld, IEnemyCounterView view)
        {
            _enemiesWorld = enemiesWorld ?? throw new ArgumentNullException(nameof(enemiesWorld));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        private int LastShowedCount => _view.ShowingCount;
        
        public void Update(float deltaTime)
        {
            int currentEnemiesCount = _enemiesWorld.Enemies.Count;

            if (LastShowedCount != currentEnemiesCount)
                _view.Show(currentEnemiesCount);
        }
    }
}