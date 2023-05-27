using System;
using System.Collections.Generic;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Tools;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public class KillsStreak : IGameLoopObject, IKillsStreak
    {
        private readonly IReadOnlyEnemiesWorld _enemiesWorld;
        private readonly IKillsStreakView _view;
        private readonly IHealth _health;
        private readonly IList<IEnemy> _alreadyKilledEnemies;

        private int _lastHealthValue;

        public KillsStreak(IReadOnlyEnemiesWorld enemiesWorld, IKillsStreakView view, IHealth characterHealth)
        {
            _enemiesWorld = enemiesWorld ?? throw new ArgumentNullException(nameof(enemiesWorld));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _health = characterHealth ?? throw new ArgumentNullException(nameof(characterHealth));
            _alreadyKilledEnemies = _enemiesWorld.DiedEnemies();
            _lastHealthValue = _health.Value;
        }

        public int Factor { get; private set; }

        public void Update(float deltaTime)
        {
            TryIncrease();

            if (_health.Value < _lastHealthValue)
                Reset();
        }

        private void Reset()
        {
            Factor = 0;
            _lastHealthValue = _health.Value;
            _view.ResetFactor();
        }

        private void TryIncrease()
        {
            foreach (IEnemy enemy in _enemiesWorld.Enemies.Keys)
            {
                if (enemy.Health.IsDied() && _alreadyKilledEnemies.Contains(enemy) == false)
                {
                    Factor++;
                    _view.Visualize(Factor);
                    _alreadyKilledEnemies.Add(enemy);
                }
            }
        }
    }
}