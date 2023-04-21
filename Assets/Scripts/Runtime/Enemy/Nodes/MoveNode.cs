using System;
using BananaParty.BehaviorTree;
using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.Model
{
    public sealed class MoveNode : BehaviorNode
    {
        private readonly IMovement _movement;
        private readonly Transform _target;
        private readonly float _distanceToStopMovement;

        public MoveNode(IMovement movement, Transform target, float distanceToStopMovement)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            _target = target ? target : throw new ArgumentNullException(nameof(target));
            _distanceToStopMovement = distanceToStopMovement.ThrowIfLessOrEqualsToZeroException();
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            Vector3 direction = _target.position - _movement.Transform.position;
            _movement.Move(direction.normalized);
            return direction.sqrMagnitude >= _distanceToStopMovement * _distanceToStopMovement
                ? BehaviorNodeStatus.Success
                : BehaviorNodeStatus.Failure;
        }
    }
}