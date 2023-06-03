using System;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class RewardForMurder : IGameLoopObject
    {
        private readonly IReadOnlyHealth _target;
        private readonly IReward _reward;
        
        private bool _isRewardApplied;

        public RewardForMurder(IReadOnlyHealth target, IReward reward)
        {
            _target = target ?? throw new ArgumentNullException(nameof(target));
            _reward = reward ?? throw new ArgumentNullException(nameof(reward));
        }

        public void Update(float deltaTime)
        {
            if (_target.IsDied() && !_isRewardApplied)
            {
                _isRewardApplied = true;
                _reward.Receive();
            }
        }
    }
}