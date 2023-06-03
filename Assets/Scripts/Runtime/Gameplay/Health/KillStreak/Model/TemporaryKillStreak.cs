using System;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class TemporaryKillStreak : IGameLoopObjectKillsStreak
    {
        private readonly IGameLoopObjectKillsStreak _killsStreak;
        private readonly float _resetCooldown;
      
        private float _time;

        public TemporaryKillStreak(IGameLoopObjectKillsStreak killsStreak, float resetCooldown = 5f)
        {
            _killsStreak = killsStreak ?? throw new ArgumentNullException(nameof(killsStreak));
            _resetCooldown = resetCooldown.ThrowIfLessOrEqualsToZeroException();
        }

        public int Factor => _killsStreak.Factor;

        public void Reset()
        {
            _killsStreak.Reset();
        }

        public void Update(float deltaTime)
        {
            _killsStreak.Update(deltaTime);
            
            if (Factor == 0)
            {
                _time = 0;
                return;
            }

            _time += deltaTime;

            if (_time >= _resetCooldown)
                Reset();
        }
    }
}