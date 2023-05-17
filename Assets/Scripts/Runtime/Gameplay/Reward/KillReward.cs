using System;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Model
{
    public class KillReward : IGameLoopObject
    {
        private readonly IHealth _health;
        private readonly IReward _reward;
        private bool _isRewardApplied;

        public KillReward(IHealth health, IReward reward)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _reward = reward ?? throw new ArgumentNullException(nameof(reward));
        }

        public void Update(float deltaTime)
        {
            if (_health.IsDied() && !_isRewardApplied)
            {
                _isRewardApplied = true;
                _reward.Apply();
            }
        }
    }
}