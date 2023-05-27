using System;
using System.Collections.Generic;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class WavesFactory : MonoBehaviour, IWavesFactory
    {
        [SerializeField] private List<WaveData> _waveData;

        private IReadOnlyDictionary<EnemyType,IEnemyFactory> _factories;
        private IEnemiesWorld _enemiesWorld;

        public void Init(IEnemiesWorld enemiesWorld, IReadOnlyDictionary<EnemyType,IEnemyFactory> factories)
        {
            _enemiesWorld = enemiesWorld ?? throw new ArgumentNullException(nameof(enemiesWorld));
            _factories = factories ?? throw new ArgumentNullException(nameof(factories));
        }

        public IWavesQueue Create()
        {
            var queue = new Queue<IWave>();

            foreach (var waveData in _waveData)
            {
                queue.Enqueue(new Wave(_factories, _enemiesWorld, waveData));
            }

            return new WavesQueue(queue);
        }
    }
}