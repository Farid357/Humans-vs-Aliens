using System;
using BananaParty.BehaviorTree;
using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.Gameplay
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
            Vector3 difference = _target.position - _movement.Transform.position;
            _movement.Move(difference.normalized);
          
            return difference.sqrMagnitude >= _distanceToStopMovement * _distanceToStopMovement
                ? BehaviorNodeStatus.Success
                : BehaviorNodeStatus.Failure;
        }
    }
}