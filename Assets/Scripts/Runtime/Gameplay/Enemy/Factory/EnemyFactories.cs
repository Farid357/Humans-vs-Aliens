using System.Collections.Generic;
using HumansVsAliens.GameLoop;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class EnemyFactories : MonoBehaviour
    {
        [SerializeField] private AlienFactory _alienFactory;
        [SerializeField] private AlienFactory _redAlienFactory;
        [SerializeField] private AlienFactory _grayAlienFactory;
        
        public void Init(IGameLoopObjectsGroup gameLoop, ICharacterStatistics statistics)
        {
            _alienFactory.Init(gameLoop, new EnemyRewardFactory(statistics, 10, 15));
            _redAlienFactory.Init(gameLoop, new EnemyRewardFactory(statistics, 1, 5));
            _grayAlienFactory.Init(gameLoop, new EnemyRewardFactory(statistics, 25, 50));
        }

        public IReadOnlyDictionary<EnemyType, IEnemyFactory> Create()
        {
            IReadOnlyDictionary<EnemyType, IEnemyFactory> factories = new Dictionary<EnemyType, IEnemyFactory>
            {
                { EnemyType.Alien, _alienFactory },
                { EnemyType.RedAlien, _redAlienFactory },
                { EnemyType.GrayAlien, _grayAlienFactory}
            };

            return factories;
        }
    }
}