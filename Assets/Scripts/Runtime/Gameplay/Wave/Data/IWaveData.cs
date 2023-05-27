using System.Collections.Generic;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public interface IWaveData
    {
        IReadOnlyList<EnemyInWaveData> Enemies { get; }
        
        IReadOnlyList<Vector3> Positions { get; }
    }
}