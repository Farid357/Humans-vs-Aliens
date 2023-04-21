using System;
using BananaParty.BehaviorTree;
using UnityEngine;

namespace HumansVsAliens.Model
{
    public sealed class Alien : MonoBehaviour, IEnemy
    {
        [SerializeField] private MovementWithNavmesh _movement;
        [SerializeField] private int _attackDamage = 10;

        private BehaviorNode _behaviorTree;

        public IHealth Health { get; private set; }

        public void Init(IReadOnlyCharacter character, IHealth health)
        {
            Health = health ?? throw new ArgumentNullException(nameof(health));
            
            _behaviorTree = new RepeatNode(new SequenceNode(new IBehaviorNode[]
            {
                new MoveNode(_movement, character.Movement.Transform, 1.2f),
                new AttackNode(character.Health, _attackDamage)
            }));
        }

        private void Update()
        {
            if (_behaviorTree.Finished)
                _behaviorTree.Reset();

            _behaviorTree.Execute((long)(Time.time * 100));
        }
    }
}