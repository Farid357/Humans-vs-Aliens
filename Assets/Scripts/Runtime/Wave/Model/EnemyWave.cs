using System;
using System.Collections.Generic;
using HumansVsAliens.Factory;
using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.Model
{
    public sealed class EnemyWave : IEnemyWave
    {
        private readonly IReadOnlyDictionary<EnemyType, IEnemyFactory> _enemyFactories;
        private readonly IEnemiesWorld _enemiesWorld;
        private readonly IEnemyWaveData _data;
        private bool _isStarted;

        public EnemyWave(IReadOnlyDictionary<EnemyType, IEnemyFactory> enemyFactories, IEnemiesWorld enemiesWorld, IEnemyWaveData data)
        {
            _enemyFactories = enemyFactories ?? throw new ArgumentNullException(nameof(enemyFactories));
            _enemiesWorld = enemiesWorld ?? throw new ArgumentNullException(nameof(enemiesWorld));
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public bool IsEnded => _enemiesWorld.EverybodyDied;

        public void Start()
        {
            if (_isStarted)
                throw new InvalidOperationException($"Wave is already started!");

            _isStarted = true;
            CreateEnemies();
        }

        private void CreateEnemies()
        {
            foreach (var enemyInWaveData in _data.Enemies)
            {
                for (var i = 0; i < enemyInWaveData.Count; i++)
                {
                    Vector3 randomPosition = _data.Positions.GetRandom();
                    EnemyType enemyType = enemyInWaveData.Type;
                    IEnemy enemy = _enemyFactories[enemyType].Create(randomPosition);
                    _enemiesWorld.Add(enemy, enemyType);
                }
            }
        }
    }
}