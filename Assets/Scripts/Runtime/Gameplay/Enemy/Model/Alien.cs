using System;
using BananaParty.BehaviorTree;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public sealed class Alien : MonoBehaviour, IEnemy
    {
        [SerializeField] private Movement _movement;
        [SerializeField] private int _attackDamage = 10;
        [SerializeField] private float _distanceToAttack = 5f;

        private BehaviorNode _behaviorTree;

        public IHealth Health { get; private set; }

        public void Init(IHealth health)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
            ICharacterSearcher forAttackCharacterSearcher = new CharacterSearcher(transform, _distanceToAttack);
         
            _behaviorTree = new RepeatNode(new ParallelSequenceNode(new IBehaviorNode[]
            {
                new SequenceNode(new IBehaviorNode[]
                {
                    new MoveToClosestCharacterNode(_movement, new CharacterSearcher(transform, 50), 1.2f),
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
            if (_behaviorTree == null)
                return;

            if (_behaviorTree.Finished)
                _behaviorTree.Reset();

            _behaviorTree?.Execute((long)(Time.time * 1000));
        }
    }
}