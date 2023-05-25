using System;
using System.Collections.Generic;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class EnemyWavesFactory : MonoBehaviour, IEnemyWavesFactory
    {
        [SerializeField] private List<EnemyWaveData> _waveData;

        private IReadOnlyDictionary<EnemyType,IEnemyFactory> _factories;
        private IEnemiesWorld _enemiesWorld;

        public void Init(IEnemiesWorld enemiesWorld, IReadOnlyDictionary<EnemyType,IEnemyFactory> factories)
        {
            _enemiesWorld = enemiesWorld ?? throw new ArgumentNullException(nameof(enemiesWorld));
            _factories = factories ?? throw new ArgumentNullException(nameof(factories));
        }

        public IEnemyWavesQueue Create()
        {
            var queue = new Queue<IEnemyWave>();

            foreach (var waveData in _waveData)
            {
                queue.Enqueue(new EnemyWave(_factories, _enemiesWorld, waveData));
            }

            return new EnemyWavesQueue(queue);
        }
    }
}