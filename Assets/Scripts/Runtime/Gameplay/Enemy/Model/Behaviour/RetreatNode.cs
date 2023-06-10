using System;
using BananaParty.BehaviorTree;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class RetreatNode : BehaviorNode
    {
        private readonly IMovement _movement;

        public RetreatNode(IMovement movement)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _movement.Move(Vector3.back);
            return BehaviorNodeStatus.Success;
        }
    }
}