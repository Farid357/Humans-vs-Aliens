using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    [Serializable]
    public class WaveData : IWaveData
    {
        [SerializeField] private List<EnemyInWaveData> _enemies;
        [SerializeField] private List<Transform> _enemiesPositions;
        
        public IReadOnlyList<EnemyInWaveData> Enemies => _enemies;
        
        public IReadOnlyList<Vector3> Positions => _enemiesPositions.Select(transform => transform.position).ToList();
    }
}