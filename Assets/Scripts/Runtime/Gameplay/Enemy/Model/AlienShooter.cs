using BananaParty.BehaviorTree;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class AlienShooter : MonoBehaviour, IEnemy
    {
        [SerializeField] private WeaponFactory _weaponFactory;
        [SerializeField] private AlienData _data;
        
        private BehaviorNode _behaviorTree;

        public IHealth Health { get; private set; }
        
        [PunRPC]
        public void Init(int healthValue)
        {
            IWeapon weapon = _weaponFactory.Create(new EnemyWeaponAim(transform, _data.DistanceToAttack));
            IHealth health = new Health(healthValue);
            _data.HealthSynchronization.Init(health);
            Health = new HealthWithView(_data.HealthSynchronization, _data.HealthView);
         
            _behaviorTree = new RepeatNode(new ParallelSequenceNode(new IBehaviorNode[]
            {
                new SequenceNode(new IBehaviorNode[]
                {
                    new IsCharacterNearNode(new CharacterSearcher(transform, 3.5f)),
                    new RetreatNode(_data.Movement),
                }),

                new SequenceNode(new IBehaviorNode[]
                {
                    new IsCharacterNearNode(new CharacterSearcher(transform, _data.DistanceToAttack)),
                    new WaitNode(0.45f),
                    new WeaponAttackNode(weapon),
                    new WaitNode(1.2f),
                })
            }));
        }

        private void Update()
        {
            if (_behaviorTree.Finished)
                _behaviorTree.Reset();

            _behaviorTree.Execute((long)(Time.time * 1000));
        }
    }
}