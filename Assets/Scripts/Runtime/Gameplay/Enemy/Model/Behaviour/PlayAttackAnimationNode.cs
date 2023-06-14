using System;
using BananaParty.BehaviorTree;
using HumansVsAliens.View;

namespace HumansVsAliens.Gameplay
{
    public class PlayAttackAnimationNode : BehaviorNode
    {
        private readonly IAttackAnimation _attackAnimation;

        public PlayAttackAnimationNode(IAttackAnimation attackAnimation)
        {
            _attackAnimation = attackAnimation ?? throw new ArgumentNullException(nameof(attackAnimation));
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _attackAnimation.PlayAttack();
            return BehaviorNodeStatus.Success;
        }
    }
}