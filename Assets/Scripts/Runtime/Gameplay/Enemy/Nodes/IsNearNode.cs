using System;
using BananaParty.BehaviorTree;
using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class IsNearNode : BehaviorNode
    {
        private readonly Transform _transform;
        private readonly Transform _target;
        private readonly float _distance;

        public IsNearNode(Transform transform, Transform target, float distance)
        {
            _transform = transform ? transform : throw new ArgumentNullException(nameof(transform));
            _target = target ? target : throw new ArgumentNullException(nameof(target));
            _distance = distance.ThrowIfLessOrEqualsToZeroException();
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            float distance = (_target.position - _transform.position).sqrMagnitude;
            return distance <= _distance * _distance ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Failure;
        }
    }
}