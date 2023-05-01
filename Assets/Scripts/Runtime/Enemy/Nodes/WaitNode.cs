using BananaParty.BehaviorTree;
using UnityEngine;

namespace HumansVsAliens.Model
{
    public class WaitNode : BehaviorNode
    {
        private float _time;
        private readonly float _duration;

        public WaitNode(float duration)
        {
            _duration = duration;
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