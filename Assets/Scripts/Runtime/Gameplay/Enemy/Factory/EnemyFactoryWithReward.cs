using System;
using HumansVsAliens.GameLoop;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class EnemyFactoryWithReward : IEnemyFactory
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly IGameLoopObjectsGroup _gameLoop;
        private readonly IRewardFactory _rewardFactory;

        public EnemyFactoryWithReward(IEnemyFactory enemyFactory, IGameLoopObjectsGroup gameLoop, IRewardFactory rewardFactory)
        {
            _enemyFactory = enemyFactory ?? throw new ArgumentNullException(nameof(enemyFactory));
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _rewardFactory = rewardFactory ?? throw new ArgumentNullException(nameof(rewardFactory));
        }

        public IEnemy Create(Vector3 position)
        {
            IEnemy enemy = _enemyFactory.Create(position);
            IReward reward = _rewardFactory.Create();
            IGameLoopObject rewardForMurder = new RewardForMurder(enemy.Health, reward);
            _gameLoop.Add(rewardForMurder);
            return enemy;
        }
    }
}