using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    [System.Serializable]
    public sealed class AlienData
    {
        [field: SerializeField] public AlienHealthView HealthView { get; private set; }
        
        [field: SerializeField] public Movement Movement { get; private set; }
        
        [field: SerializeField] public HealthSynchronization HealthSynchronization { get; private set; }
        
        [field: SerializeField] public float DistanceToAttack { get; private set; } = 8f;
    }
}