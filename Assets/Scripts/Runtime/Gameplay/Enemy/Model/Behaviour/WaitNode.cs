using BananaParty.BehaviorTree;
using HumansVsAliens.Tools;
using UnityEngine;

namespace HumansVsAliens.Gameplay
{
    public class WaitNode : BehaviorNode
    {
        private readonly float _duration;
        private float _time;

        public WaitNode(float duration)
        {
            _duration = duration.ThrowIfLessOrEqualsToZeroException();
        }

        public override string Name => $"{base.Name} {_duration}";

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _time += Time.deltaTime;

            if (_time >= _duration)
            {
                _time = 0f;
                return BehaviorNodeStatus.Success;
            }

            return BehaviorNodeStatus.Failure;
        }
    }
}