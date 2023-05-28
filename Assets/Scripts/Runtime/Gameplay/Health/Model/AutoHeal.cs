using System;
using HumansVsAliens.GameLoop;
using HumansVsAliens.Tools;

namespace HumansVsAliens.Gameplay
{
    public class AutoHeal : IGameLoopObject
    {
        private readonly IReadOnlyWavesLoop _wavesLoop;
        private readonly IHealth _health;
        private bool _hasHealed;

        public AutoHeal(IReadOnlyWavesLoop wavesLoop, IHealth health)
        {
            _wavesLoop = wavesLoop ?? throw new ArgumentNullException(nameof(wavesLoop));
            _health = health ?? throw new ArgumentNullException(nameof(health));
        }

        public void Update(float deltaTime)
        {
            if (_wavesLoop.Status == WavesLoopStatus.WaitNextWave && !_hasHealed)
                Heal();

            if (_wavesLoop.Status == WavesLoopStatus.WaveIsGoing)
                _hasHealed = false;
        }

        private void Heal()
        {
            _health.Heal();
            _hasHealed = true;
        }
    }
}