using System;
using UnityEngine;

namespace HumansVsAliens.Model
{
    [Serializable]
    public struct EnemyInWaveData
    {
        [field: SerializeField] public int Count { get; private set; }
        
        [field: SerializeField] public EnemyType Type { get; private set; }
    }
}