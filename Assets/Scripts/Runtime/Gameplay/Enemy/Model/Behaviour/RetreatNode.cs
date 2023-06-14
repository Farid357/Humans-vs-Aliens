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
            if (Collide(Vector3.back))
            {
                if (Collide(Vector3.left) && Collide(Vector3.right))
                    return BehaviorNodeStatus.Failure;

                _movement.Move(Collide(Vector3.left) ? Vector3.right : Vector3.left);
                return BehaviorNodeStatus.Success;
            }

            _movement.Move(Vector3.back);
            return BehaviorNodeStatus.Success;
        }

        private bool Collide(Vector3 direction)
        {
            var ray = new Ray(_movement.Position, direction);
            return Physics.Raycast(ray, 1.4f);
        }
    }
}