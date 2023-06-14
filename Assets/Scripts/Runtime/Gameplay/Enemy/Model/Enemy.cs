using BananaParty.BehaviorTree;
using HumansVsAliens.Tools;
using HumansVsAliens.View;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    [RequireComponent(typeof(PhotonView))]
    public abstract class Enemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private EnemyHealthView _healthView;
        [SerializeField] private HealthSynchronization _healthSynchronization;
        [SerializeField] private Movement _movement;
        [SerializeField, Min(0.1f)] private float _distanceToAttack = 2.5f;

        private IBehaviorNode _behaviorTree;

        public IHealth Health { get; private set; }

        protected IMovement Movement => _movement;

        protected float DistanceToAttack => _distanceToAttack;

        [PunRPC]
        public void Init(int health)
        {
            _healthSynchronization.Init(new Health(health));
            Health = new HealthWithView(_healthSynchronization, _healthView);
            _behaviorTree = CreateBehaviourTree();
        }

        private void Update()
        {
            if (_behaviorTree.Finished())
                _behaviorTree.Reset();

            _behaviorTree.Execute((long)(Time.time * 1000));
        }

        protected abstract IBehaviorNode CreateBehaviourTree();
    }
}