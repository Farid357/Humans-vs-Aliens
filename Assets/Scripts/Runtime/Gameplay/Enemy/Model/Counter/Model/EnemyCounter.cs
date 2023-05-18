using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Tools;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public class EnemyCounter : IGameLoopObject
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
            int currentEnemiesCount = _enemiesWorld.Enemies.Where(enemy => enemy.Key.Health.IsAlive).Count();

            if (_lastShowedCount != currentEnemiesCount)
            {
                _view.Show(currentEnemiesCount);
                _lastShowedCount = currentEnemiesCount;
            }
        }
    }
}