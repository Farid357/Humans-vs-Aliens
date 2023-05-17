using System;
using System.Collections.Generic;
using HumansVsAliens.Model;
using UnityEngine;

namespace HumansVsAliens.Factory
{
    public class EnemyWavesFactory : MonoBehaviour, IEnemyWavesFactory
    {
        [SerializeField] private List<EnemyWaveData> _waveData;
        [SerializeField] private AlienFactory _alienFactory;
        [SerializeField] private AlienFactory _redMonsterFactory;

        private IEnemiesWorld _enemiesWorld;

        public void Init(IEnemiesWorld enemiesWorld, IReadOnlyCharacter character)
        {
            _enemiesWorld = enemiesWorld ?? throw new ArgumentNullException(nameof(enemiesWorld));
            _alienFactory.Init(character);
            _redMonsterFactory.Init(character);
        }

        public IEnemyWavesQueue Create()
        {
            var queue = new Queue<IEnemyWave>();
            IReadOnlyDictionary<EnemyType, IEnemyFactory> factories = new Dictionary<EnemyType, IEnemyFactory>
            {
                { EnemyType.Alien, _alienFactory},
                {EnemyType.RedMonster, _redMonsterFactory }
            };

            foreach (var enemyWaveData in _waveData)
            {
                queue.Enqueue(new EnemyWave(factories, _enemiesWorld, enemyWaveData));
            }

            return new EnemyWavesQueue(queue);
        }
    }
}