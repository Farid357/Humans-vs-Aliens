using System;
using BananaParty.BehaviorTree;
using UnityEngine;

namespace HumansVsAliens.Model
{
    public sealed class Alien : MonoBehaviour, IEnemy
    {
        [SerializeField] private MovementWithNavmesh _movement;
        [SerializeField] private int _attackDamage = 10;
        [SerializeField] private float _distanceToAttack = 5f;
        
        private BehaviorNode _behaviorTree;

        public IHealth Health { get; private set; }

        public void Init(IReadOnlyCharacter character, IHealth health)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
            Transform characterTransform = character.Movement.Transform;

            _behaviorTree = new RepeatNode(new SequenceNode(new IBehaviorNode[]
            {
                new ParallelSequenceNode(new IBehaviorNode[]
                {
                    new MoveNode(_movement, characterTransform, 1.2f),
                }),
                
                new ParallelSequenceNode(new IBehaviorNode[]
                {
                    new IsNearNode(_movement.Transform, characterTransform, _distanceToAttack),
                    new WaitNode(2.2f),
                    new AttackNode(character.Health, _attackDamage)
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