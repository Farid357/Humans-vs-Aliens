using HumansVsAliens.GameLoop;
using HumansVsAliens.Networking;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class EnemyWavesFactory : MonoBehaviour, IEnemyWavesFactory
    {
        [SerializeField] private List<EnemyWaveData> _waveData;
        [SerializeField] private AlienFactory _alienFactory;
        [SerializeField] private AlienFactory _redMonsterFactory;

        private IEnemiesWorld _enemiesWorld;

        public void Init(IEnemiesWorld enemiesWorld, IReadOnlyCharacter character, IGameLoopObjectsGroup gameLoop, 
            ICharacterStatistics statistics, IServer server)
        {
            _enemiesWorld = enemiesWorld ?? throw new ArgumentNullException(nameof(enemiesWorld));
            _alienFactory.Init(character, gameLoop, statistics, server);
            _redMonsterFactory.Init(character, gameLoop, statistics, server);
        }

        public IEnemyWavesQueue Create()
        {
            var queue = new Queue<IEnemyWave>();
            IReadOnlyDictionary<EnemyType, IEnemyFactory> factories = new Dictionary<EnemyType, IEnemyFactory>
            {
                { EnemyType.Alien, _alienFactory},
                {EnemyType.RedMonster, _redMonsterFactory }
            };

            foreach (var waveData in _waveData)
            {
                queue.Enqueue(new EnemyWave(factories, _enemiesWorld, waveData));
            }

            return new EnemyWavesQueue(queue);
        }
    }
}