using System;
using System.Collections.Generic;
using HumansVsAliens.GameLoop;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class EnemyFactories : MonoBehaviour
    {
        [SerializeField] private EnemyFactory _alienFactory;
        [SerializeField] private EnemyFactory _redAlienFactory;
        [SerializeField] private EnemyFactory _grayAlienFactory;

        private IGameLoopObjectsGroup _gameLoop;
        private ICharacterStatistics _statistics;

        public void Init(IGameLoopObjectsGroup gameLoop, ICharacterStatistics statistics)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
            _statistics = statistics ?? throw new ArgumentNullException(nameof(statistics));
        }

        public IReadOnlyDictionary<EnemyType, IEnemyFactory> Create()
        {
            IReadOnlyDictionary<EnemyType, IEnemyFactory> factories = new Dictionary<EnemyType, IEnemyFactory>
            {
                { EnemyType.Alien, new EnemyFactoryWithReward(_alienFactory, _gameLoop, CreateRewardFactory(10, 15)) },
                { EnemyType.RedAlien, new EnemyFactoryWithReward(_redAlienFactory, _gameLoop, CreateRewardFactory(1, 5))},
                { EnemyType.GrayAlien, new EnemyFactoryWithReward(_grayAlienFactory, _gameLoop, CreateRewardFactory(25, 50)) }
            };

            return factories;
        }

        private IRewardFactory CreateRewardFactory(int money, int scoreCount)
        {
            return new EnemyRewardFactory(_statistics, money, scoreCount);
        }
    }
}