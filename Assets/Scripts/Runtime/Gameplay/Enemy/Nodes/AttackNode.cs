using System;
using BananaParty.BehaviorTree;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public sealed class AttackNode : BehaviorNode
    {
        private readonly IHealth _health;
        private readonly int _damage;

        public AttackNode(IHealth health, int damage)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _damage = damage.ThrowIfLessThanOrEqualsToZeroException();
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_health.IsAlive)
            {
                _health.TakeDamage(_damage);
                return BehaviorNodeStatus.Success;
            }

            return BehaviorNodeStatus.Failure;
        }
    }
}