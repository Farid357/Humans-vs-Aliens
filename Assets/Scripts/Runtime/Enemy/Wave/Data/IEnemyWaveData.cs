using System.Collections.Generic;
using UnityEngine;

namespace HumansVsAliens.Model
{
    public interface IEnemyWaveData
    {
        IReadOnlyList<EnemyInWaveData> Enemies { get; }
        
        IReadOnlyList<Vector3> Positions { get; }
    }
}