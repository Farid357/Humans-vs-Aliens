using System;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    [Serializable]
    public struct EnemyInWaveData
    {
        [field: SerializeField] public int Count { get; private set; }
        
        [field: SerializeField] public EnemyType Type { get; private set; }
    }
}