using System;
using System.Collections.Generic;
using HumansVsAliens.Gameplay;
using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class EnemyWave : IEnemyWave
    {
        private readonly IReadOnlyDictionary<EnemyType, IEnemyFactory> _enemyFactories;
        private readonly IEnemiesWorld _enemiesWorld;
        private readonly IEnemyWaveData _data;
        private readonly List<Vector3> _busyEnemyPositions;

        public EnemyWave(IReadOnlyDictionary<EnemyType, IEnemyFactory> enemyFactories, IEnemiesWorld enemiesWorld, IEnemyWaveData data)
        {
            _enemyFactories = enemyFactories ?? throw new ArgumentNullException(nameof(enemyFactories));
            _enemiesWorld = enemiesWorld ?? throw new ArgumentNullException(nameof(enemiesWorld));
            _data = data ?? throw new ArgumentNullException(nameof(data));
            _busyEnemyPositions = new List<Vector3>();
        }

        public bool IsEnded => _enemiesWorld.EverybodyDied;

        public void Start()
        {
            _busyEnemyPositions.Clear();
            CreateEnemies();
        }

        private void CreateEnemies()
        {
            foreach (var enemyInWaveData in _data.Enemies)
            {
                for (var i = 0; i < enemyInWaveData.Count; i++)
                {
                    Vector3 randomPosition = _data.Positions.GetRandom();

                    while (_busyEnemyPositions.Contains(randomPosition))
                    {
                        if (_busyEnemyPositions.Count == _data.Positions.Count)
                            throw new InvalidOperationException("Doesn't contains any positions for spawn!");

                        randomPosition = _data.Positions.GetRandom();
                    }

                    _busyEnemyPositions.Add(randomPosition);
                    EnemyType enemyType = enemyInWaveData.Type;
                    IEnemy enemy = _enemyFactories[enemyType].Create(randomPosition);
                    _enemiesWorld.Add(enemy, enemyType);
                }
            }
        }
    }
}