using BananaParty.BehaviorTree;
using Photon.Pun;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    [RequireComponent(typeof(PhotonView))]
    public sealed class Alien : MonoBehaviour, IEnemy
    {
        [SerializeField] private AlienData _data;
        [SerializeField] private int _attackDamage = 10;

        private BehaviorNode _behaviorTree;

        public IHealth Health => _data.Health;
        
        [PunRPC]
        public void Init(int healthValue)
        {
            _data.Init(healthValue);
            ICharacterSearcher forAttackCharacterSearcher = new CharacterSearcher(transform, _data.DistanceToAttack);
         
            _behaviorTree = new RepeatNode(new ParallelSequenceNode(new IBehaviorNode[]
            {
                new SequenceNode(new IBehaviorNode[]
                {
                    new MoveToClosestCharacterNode(_data.Movement, new CharacterSearcher(transform, 50), 1.2f),
                }),

                new SequenceNode(new IBehaviorNode[]
                {
                    new IsCharacterNearNode(forAttackCharacterSearcher),
                    new WaitNode(1.2f),
                    new AttackClosestCharacterNode(forAttackCharacterSearcher, _attackDamage),
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