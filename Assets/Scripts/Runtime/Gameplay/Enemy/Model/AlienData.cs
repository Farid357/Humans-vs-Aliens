using HumansVsAliens.View;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    [System.Serializable]
    public sealed class AlienData
    {
        [SerializeField] private AlienHealthView _healthView;
        [SerializeField] private Movement _movement;
        [SerializeField] private HealthSynchronization _healthSynchronization;

        public IHealth Health { get; private set; }
      
        public IMovement Movement => _movement;
        
        [field: SerializeField] public float DistanceToAttack { get; private set; }

        public void Init(int health)
        {
            _healthSynchronization.Init(new Health(health));
            Health = new HealthWithView(_healthSynchronization, _healthView);
        }
    }
}